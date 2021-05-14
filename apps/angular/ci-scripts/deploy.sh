#!/bin/bash
sleep_time=2
domain=DOMAIN
space_deployment_path=deployment/BITBUCKET_REPO_SLUG/BITBUCKET_BUILD_NUMBER.BITBUCKET_STEP_RUN_NUMBER.$domain

# Step1 Start Pull Packages from Storage
cowsay "Step1 Start Pull Packages from Storage ..."
sudo mkdir -p /var/www/$space_deployment_path /var/www/new.$domain

sudo s3cmd --config /etc/.s3cfg \
      get s3://SPACE_NAME/$space_deployment_path/frontend.tar.gz \
      /var/www/$space_deployment_path
test $? -eq 0 || exit 1

cowsay "Step1 Status Code $?"

# Step2 Unzipping a Pulled Package
cowsay "Step2 Unzipping a Pulled Package ..."
sudo tar -v -z -x -f /var/www/$space_deployment_path/frontend.tar.gz -C /var/www/new.$domain
test $? -eq 0 || exit 1

cowsay "Status Code sudo tar -v -z -x -f /var/www/$space_deployment_path/frontend.tar.gz -C /var/www/new.$domain Status Code $?"

# Change Directory Owner and Permission 
cowsay "Change Directory Owner and Permission ..."
sudo chmod -R 2755 /var/www/
sudo chown -R www-data:www-data /var/www/

# Update Deployment Directories
cowsay "Update Deployment Directories ..."
sudo mv /var/www/$domain /var/www/old.$domain
sudo mv /var/www/new.$domain /var/www/$domain

# Nginx Status
cowsay "Nginx Status ..."
sudo systemctl restart nginx.service
cowsay "Status Code for sudo systemctl restart nginx.service Status Code $?"
sleep $sleep_time
sudo systemctl status nginx.service

# Step4 Remove Unused Files
cowsay "Step4 Remove Unused Files ..."
sudo rm -rf /var/www/old.$domain
sudo rm -rf /var/www/$space_deployment_path

echo "Done!"