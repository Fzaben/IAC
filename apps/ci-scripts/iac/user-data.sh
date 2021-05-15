#!/bin/bash
echo "=>>>>>>>>>>>>>>>>>>>>>>>>>>> Start cloud init <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<="

export WEBHOOK_URL="https://hooks.slack.com/services/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"
export domain=demo.drah.im
export jc_connet_key=4ce092b7868d956f81c25f884ba39a839a37cf92
export email=faisal@aqwas.sa
export SSH_USER=do
export SSH_PORT=2222
export DOTNET_VERSION=5.0
export UBUNTU_VERSION=20.04
export NODE_VERSION=12

apt-get update -y -q
curl -X POST -H 'Content-type: application/json' --data '{"text":"Start cloud init"}' $WEBHOOK_URL

adduser --disabled-password --gecos "" do && \
echo "do ALL=(ALL:ALL) NOPASSWD: ALL" | sudo tee /etc/sudoers.d/do && \
usermod -aG sudo do && \
cp -r /root/.ssh/ /home/do/ && \
chown -R do:do /home/do/.ssh/ && \
chmod -R 700 /home/do/.ssh/
curl -X POST -H 'Content-type: application/json' --data '{"text":"Add User"}' $WEBHOOK_URL

sudo sed -i 's/PermitRootLogin yes/PermitRootLogin no/g' /etc/ssh/sshd_config && \
sudo sed -i 's/#PubkeyAuthentication yes/PubkeyAuthentication yes/g' /etc/ssh/sshd_config && \
sudo sed -i 's/#Port 22/Port 2222/g' /etc/ssh/sshd_config && \
sudo passwd -l root

curl -X POST -H 'Content-type: application/json' --data '{"text":"no root"}' $WEBHOOK_URL

# Enable server firewall
sudo ufw allow OpenSSH
sudo ufw allow 80/tcp
sudo ufw allow 443/tcp
sudo ufw allow 2222/tcp  
yes | sudo ufw enable
sudo ufw status
sudo ufw reload

curl -X POST -H 'Content-type: application/json' --data '{"text":"update firewall"}' $WEBHOOK_URL

curl --tlsv1.2 --silent --show-error --header 'x-connect-key: 4ce092b7868d956f81c25f884ba39a839a37cf92' https://kickstart.jumpcloud.com/Kickstart | sudo bash

curl -X POST -H 'Content-type: application/json' --data '{"text":"jumpcloud integrated"}' $WEBHOOK_URL


DEBIAN_FRONTEND='noninteractive' apt-get -q -y -o Dpkg::Options::='--force-confdef' -o Dpkg::Options::='--force-confold' upgrade
sleep 3

curl -X POST -H 'Content-type: application/json' --data '{"text":"upgrade os"}' $WEBHOOK_URL

DEBIAN_FRONTEND='noninteractive' apt-get -q -y -o Dpkg::Options::='--force-confdef' -o Dpkg::Options::='--force-confold' dist-upgrade
sleep 3

sudo apt-get -q -y autoremove --purge
sudo apt-get -q -y clean

## Install prerequisite packages (nginx, certbot, python3, curl, make, zip, ..... ) 
echo "Install prerequisite packages (nginx, certbot, python3, curl, make, zip, ..... ) "

sudo apt-get update -y -q  && sudo apt-get -y -q install nginx certbot python3-certbot-nginx fail2ban
sleep 3
sudo apt-get update -y -q  && sudo apt-get -y -q install wget zip unzip curl lsb-release make cowsay s3cmd
sleep 3
sudo apt-get update -y -q  && sudo apt-get -y -q install software-properties-common openssh-server openssh-client  
sleep  3

curl -X POST -H 'Content-type: application/json' --data '{"text":"nstall prerequisite packages"}' $WEBHOOK_URL

## dotnet
sudo wget -q https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo add-apt-repository universe -y
sudo apt-get install apt-transport-https -fyqq
sudo apt-get update -y -q
sudo apt-get install dotnet-sdk-5.0 -fyqq
sleep3

curl -X POST -H 'Content-type: application/json' --data '{"text":"install dotnet"}' $WEBHOOK_URL

# node
sudo apt-get update -y -q
sudo apt-get clean -y -q
sudo apt-get autoremove -y -q

curl -sL https://deb.nodesource.com/setup_12.x | sudo -E bash -

sudo apt-get install -y -q nodejs

sudo npm install -g serve

curl -X POST -H 'Content-type: application/json' --data '{"text":"install node"}' $WEBHOOK_URL

sudo systemctl restart sshd ssh

sudo mkdir -p /var/www/admin.$domain /var/www/$domain /var/www/frontend.$domain
sudo chmod -R 2755 /var/www
sudo chown -R www-data:www-data /var/www
sudo rm -f /etc/nginx/sites-*/default
sudo rm -rf /var/www/html

echo "=>>>>>>>>>>>>>>>>>>>>>>>>>>> End cloud init <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<="
