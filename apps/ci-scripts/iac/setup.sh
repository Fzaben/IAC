#!/bin/bash
## Update and Upgrade OS
echo Update and Upgrade OS
export WEBHOOK_URL="https://hooks.slack.com/services/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"

sudo apt-get -q -y update 
curl -X POST -H 'Content-type: application/json' --data '{"text":"Start cloud init"}' $WEBHOOK_URL

DEBIAN_FRONTEND='noninteractive' apt-get -q -y -o Dpkg::Options::='--force-confdef' -o Dpkg::Options::='--force-confold' upgrade
DEBIAN_FRONTEND='noninteractive' apt-get -q -y -o Dpkg::Options::='--force-confdef' -o Dpkg::Options::='--force-confold' dist-upgrade
sudo apt-get -q -y autoremove --purge
sudo apt-get -q -y clean
curl -X POST -H 'Content-type: application/json' --data '{"text":"upgrade os"}' $WEBHOOK_URL


## Install prerequisite packages (nginx, certbot, python3, curl, make, zip, ..... ) 
echo "Install prerequisite packages (nginx, certbot, python3, curl, make, zip, ..... ) "
sudo apt-get update -y -q  && sudo apt-get -y -q install nginx certbot python3-certbot-nginx fail2ban
sudo apt-get update -y -q  && sudo apt-get -y -q install wget zip unzip curl lsb-release make cowsay s3cmd
sudo apt-get update -y -q  && sudo apt-get -y -q install software-properties-common openssh-server openssh-client  
curl -X POST -H 'Content-type: application/json' --data '{"text":"install prerequisite packages"}' $WEBHOOK_URL


## dotnet
sudo wget -q https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo add-apt-repository universe -y
sudo apt-get install apt-transport-https -fyqq
sudo apt-get update -y
sudo apt-get install dotnet-sdk-5.0 -fyqq
curl -X POST -H 'Content-type: application/json' --data '{"text":"install dotnet"}' $WEBHOOK_URL

# node
curl -sL https://deb.nodesource.com/setup_12.x | sudo -E bash -
sudo apt-get install -y nodejs 
sudo npm install -g serve
curl -X POST -H 'Content-type: application/json' --data '{"text":"install node"}' $WEBHOOK_URL
