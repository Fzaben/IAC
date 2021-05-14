include .env
export

do:	
	- docker run -it -v $(shell pwd):/work fzaben/devops

keygen:
	- mkdir -p /work/.ssh
	- yes | ssh-keygen -t rsa -b 4096 -f $(PRIVATE_KEY_PATH) -N '' -C ''
	- chmod 700 -R /work/.ssh

## Server Connetion 
clean-old-keys:
	- ssh-keygen -f /work/.ssh/known_hosts -R $(REMOTE_SERVER)

connect: clean-old-keys
	- $(attach)

install-mssql: clean-old-keys
	- $(attach) 'bash -s' < ./ubuntu-setup-mssql.sh

nginx:
	- $(attach) 'bash -s' < ./iac/setup.sh

service:
	- $(attach) 'bash -s' < ./iac/setup.sh

archive:
	- tar cfzv angular.tar.gz -C apps/angular/dist ./
	- tar cfzv auth.tar.gz  -C apps/aspnet-core/src/devops.IdentityServer/bin/Release/net5.0/ubuntu.20.04-x64/publish/ ./
	- tar cfzv api.tar.gz  -C apps/aspnet-core/src/devops.HttpApi.Host/bin/Release/net5.0/ubuntu.20.04-x64/publish/ ./
	- tar cfzv migrator.tar.gz  -C apps/aspnet-core/src/devops.DbMigrator/bin/Release/net5.0/ubuntu.20.04-x64/publish/ ./

cpp:
	- scp -i .ssh/id_rsa -P $(SSH_PORT) *.tar.gz  $(SERVER):~/
# - ssh -i $(PRIVATE_KEY_PATH) $(SERVER) bash -s 'cd /var/www &&  mkdir -p app && tar -zxf app.tar.gz -C app'

unarchive:
# - mkdir -p $(REMOTE_SERVER)
# - tar -zxf app.tar.gz -C $(REMOTE_SERVER)
	- ssh $(HOST_KEY_CHECKING) -i $(PRIVATE_KEY_PATH) $(SERVER) 'bash -s mkdir -p /var/www'  
	- ssh $(HOST_KEY_CHECKING) -i $(PRIVATE_KEY_PATH) $(SERVER) 'bash -s tar xfzv app.tar.gz -C $(REMOTE_SERVER)''

# tar -czf mobile-api.gz -C ./FireApp.MobileAPI/bin/Release/net5/publish .

copy-pub-key:
	- cat $(TF_VAR_pub_key_devops) | ssh root@test.devops.terkwaz.com "cat >>  ~/.ssh/authorized_keys"

previent-root:
	- cat ~/etc/ssh/sshd_config | ssh -i $(TF_VAR_pub_key_devops) root@test.devops.terkwaz.com "cat >  /etc/ssh/sshd_config && systemctl restart sshd.service "

%:  %-default
	- @  true
