#!/bin/bash
sleep_time=2
appsettings_environment=APPSETTINGS_ENVIRONMENT
domain=DOMAIN
space_deployment_path=deployment/BITBUCKET_REPO_SLUG/BITBUCKET_BUILD_NUMBER.BITBUCKET_STEP_RUN_NUMBER.$domain

# Step1 Start Pull Packages from Storage
cowsay "Step1 Start Pull Packages from Storage ..."

sudo mkdir -p /var/www/$space_deployment_path /var/www/migrator.$domain /var/www/new.$domain /var/www/new.admin.$domain

sudo s3cmd --config /etc/.s3cfg get s3://SPACE_NAME/$space_deployment_path/** /var/www/$space_deployment_path
test $? -eq 0 || exit 1
cowsay "Step1 Status Code $?"

# Step2 Unzipping a Pulled Packages
cowsay "Step2 Unzipping a Pulled Packages ..."

sudo tar -v -z -x -f /var/www/$space_deployment_path/MyCompanyName.AbpZeroTemplate.Migrator.tar.gz -C /var/www/migrator.$domain
test $? -eq 0 || exit 1
cowsay "Status Code tar -v -z -x -f /var/www/$space_deployment_path/MyCompanyName.AbpZeroTemplate.Migrator.tar.gz -C /var/www/migrator Status Code $?"

sudo tar -v -z -x -f /var/www/$space_deployment_path/MyCompanyName.AbpZeroTemplate.Web.Host.tar.gz -C /var/www/new.$domain
test $? -eq 0 || exit 1
cowsay "Status Code tar -v -z -x -f /var/www/$space_deployment_path/MyCompanyName.AbpZeroTemplate.Web.Host.tar.gz -C /var/www/new Status Code $?"

sudo tar -v -z -x -f /var/www/$space_deployment_path/MyCompanyName.AbpZeroTemplate.Web.Mvc.tar.gz -C /var/www/new.admin.$domain
test $? -eq 0 || exit 1
cowsay "Status Code tar -v -z -x -f /var/www/$space_deployment_path/MyCompanyName.AbpZeroTemplate.Web.Mvc.tar.gz -C /var/www/admin.new Status Code $?"

rm -f /var/www/migrator.$domain/appsettings.json
cp -f /var/www/$space_deployment_path/appsettings.$appsettings_environment.json /var/www/migrator.$domain/appsettings.json

mv /var/www/$space_deployment_path/appsettings.$appsettings_environment.json /var/www/new.$domain/appsettings.$appsettings_environment.json
mv /var/www/$space_deployment_path/mvc.appsettings.$appsettings_environment.json /var/www/new.admin.$domain/appsettings.$appsettings_environment.json

cowsay "Status Code mv /var/www/$space_deployment_path/appsettings.$appsettings_environment.json /var/www/new/appsettings.$appsettings_environment.json Status Code $?"

# Change Directory Owner and Permission 
cowsay "Change Directory Owner and Permission ..."
sudo chmod -R 2755 /var/www/
sudo chown -R www-data:www-data /var/www/

# Step3 Stop service
cowsay "Step3 Stop service ..."
sudo systemctl stop $domain.service
sudo systemctl stop admin.$domain.service

# Step4 Database Migration 
cowsay "Step4 Database Migration ..."
cd /var/www/migrator.$domain
dotnet MyCompanyName.AbpZeroTemplate.Migrator.dll -s
test $? -eq 0 || exit 1

cowsay "Status Code for dotnet MyCompanyName.AbpZeroTemplate.Migrator.dll -s Status Code $?"

# Update Deployment Directories
cowsay "Update Deployment Directories ..."
sudo mv /var/www/$domain /var/www/old.$domain
sudo mv /var/www/admin.$domain /var/www/old.admin.$domain
sudo cp -rf /var/www/new /var/www/$domain
sudo cp -rf /var/www/new.admin /var/www/admin.$domain

# Change Directory Owner and Permission 
cowsay "Change Directory Owner and Permission ..."
sudo chown -R www-data:www-data /var/www/
sudo chmod -R 2755 /var/www/

# Step5 Start services ..
cowsay "echo Step5 Start services ..."
sudo systemctl start $domain.service
sudo systemctl start admin.$domain.service

cowsay "Status Code for sudo systemctl start $domain.service Status Code $?"

sleep $sleep_time
sudo systemctl status $domain.service
sudo systemctl status admin.$domain.service

# Nginx Status
cowsay "Nginx Status ..."
sudo systemctl restart nginx.service
cowsay "Status Code for sudo systemctl restart nginx.service Status Code $?"

sleep $sleep_time
sudo systemctl status nginx.service

# Database Status
cowsay "Database Status ..."
sudo systemctl status database.service

# Step6 Remove Unused Files
cowsay "Step6 Remove Unused Files ..."
sudo rm -rf /var/www/$space_deployment_path
sudo rm -rf /var/www/migrator.$domain
sudo rm -rf /var/www/new.$domain
sudo rm -rf /var/www/new.admin.$domain
sudo rm -rf /var/www/old.$domain
sudo rm -rf /var/www/old.admin.$domain

echo "Done!"