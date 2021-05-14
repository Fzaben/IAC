include .env
export

do:	
	- docker run -it -v $(shell pwd):/work fzaben/devops

init: 
	- make -C terraform
keygen:
	- mkdir -p $(SSH_PATH)
	- yes | ssh-keygen -t rsa -b 4096 -f $(PRIVATE_KEY_PATH) -N '' -C ''
	- chmod 700 -R $(SSH_PATH)

## Server Connetion 
clean-old-keys:
	- ssh-keygen -f $(SSH_PATH)/known_hosts -R $(REMOTE_SERVER)

connect: clean-old-keys
	- $(attach)

install-mssql: clean-old-keys
	- $(attach) 'bash -s' < ./ubuntu-setup-mssql.sh

install-mssql-with-docker: clean-old-keys
	- $(attach) sudo chmod 666 /var/run/docker.sock
	- $(scp) apps/docker-compose.yml  $(SERVER):~/
	- $(attach) docker-compose -f /home/$(SSH_USER)/docker-compose.yml up -d 

archive:
	- tar cfzv angular.tar.gz -C apps/angular/dist ./
	- tar cfzv auth.tar.gz -C apps/aspnet-core/src/devops.IdentityServer/bin/Release/net5.0/ubuntu.20.04-x64/publish/ ./
	- tar cfzv api.tar.gz -C apps/aspnet-core/src/devops.HttpApi.Host/bin/Release/net5.0/ubuntu.20.04-x64/publish/ ./
	- tar cfzv migrator.tar.gz -C apps/aspnet-core/src/devops.DbMigrator/bin/Release/net5.0/ubuntu.20.04-x64/publish/ ./

cpp:
	- $(scp) *.tar.gz  $(SERVER):~/
# - ssh -i $(PRIVATE_KEY_PATH) $(SERVER) bash -s 'cd /var/www &&  mkdir -p app && tar -zxf app.tar.gz -C app'

unarchive:
	- $(attach) 'bash -s mkdir -p /var/www' 
	- $(attach) 'bash -s tar xfzv app.tar.gz -C $(REMOTE_SERVER)'

%:  %-default
	- @  true
