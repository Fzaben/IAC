include ../.env
include .env
export 
## Infrastructrue Commands
update-user-data:
	- sed -i 's/SSH_USER/$(SSH_USER)/g' user-data.sh
	- sed -i 's/SSH_PORT/$(SSH_PORT)/g' user-data.sh
	- sed -i 's/SLACK_HOOK_URL/$(SLACK_HOOK_URL)/g' user-data.sh
	- sed -i 's/IS_REBOOT_ENABLED/$(IS_REBOOT_ENABLED)/g' user-data.sh
	- sed -i 's/JC_CONNECT_KEY/$(JC_CONNECT_KEY)/g' user-data.sh

init:
	- terraform providers
	- terraform init
plan:
	- terraform plan -out terraform.tfplan

apply: ## print this help
	- terraform apply -auto-approve

destroy: ## print this help
	- terraform destroy -auto-approve

refresh:
	- terraform refresh

%:  %-default
	- @  true
