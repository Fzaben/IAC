#!/bin/bash
echo "=>>>>>>>>>>>>>>>>>>>>>>>>>>> Start cloud init <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<="
export WEBHOOK_URL="https://hooks.slack.com/services/SLACK_HOOK_URL"
export jc_connet_key=JC_CONNECT_KEY
export ssh_user=SSH_USER
export ssh_port=SSH_PORT
export is_reboot_enabled=IS_REBOOT_ENABLED

curl -X POST -H 'Content-type: application/json' --data '{"text":"Start cloud init"}' $WEBHOOK_URL

apt-get update -y -q

curl -X POST -H 'Content-type: application/json' --data '{"text":"Add User"}' $WEBHOOK_URL
adduser --disabled-password --gecos "" $ssh_user && \
echo "$ssh_user ALL=(ALL:ALL) NOPASSWD: ALL" | sudo tee /etc/sudoers.d/$ssh_user && \
usermod -aG sudo $ssh_user && \
cp -r /root/.ssh/ /home/$ssh_user/ && \
chown -R $ssh_user:$ssh_user /home/$ssh_user/.ssh/ && \
chmod -R 700 /home/$ssh_user/.ssh/

curl -X POST -H 'Content-type: application/json' --data '{"text":"disable root login using ssh"}' $WEBHOOK_URL

sudo sed -i 's/PermitRootLogin yes/PermitRootLogin no/g' /etc/ssh/sshd_config && \
sudo sed -i 's/#PubkeyAuthentication yes/PubkeyAuthentication yes/g' /etc/ssh/sshd_config && \
sudo sed -i 's/#Port 22/Port 2222/g' /etc/ssh/sshd_config && \
sudo passwd -l root

# Enable server firewall
echo Enable server firewall
curl -X POST -H 'Content-type: application/json' --data '{"text":"update firewall"}' $WEBHOOK_URL

sudo ufw allow OpenSSH
sudo ufw allow 80/tcp
sudo ufw allow 443/tcp
sudo ufw allow $ssh_port/tcp  
yes | sudo ufw enable
sudo ufw status
sudo ufw reload
sudo systemctl restart sshd ssh

# Integrate JumpCloud ---
echo Integrate JumpCloud ---
curl -X POST -H 'Content-type: application/json' --data '{"text":"Integrate JumpCloud"}' $WEBHOOK_URL

curl --tlsv1.2 --silent --show-error --header 'x-connect-key: 4ce092b7868d956f81c25f884ba39a839a37cf92' https://kickstart.jumpcloud.com/Kickstart | sudo bash

# Upgrade OS --- 
echo "Upgrade OS"
curl -X POST -H 'Content-type: application/json' --data '{"text":"Upgrade OS"}' $WEBHOOK_URL

DEBIAN_FRONTEND='noninteractive' apt-get -q -y -o Dpkg::Options::='--force-confdef' -o Dpkg::Options::='--force-confold' upgrade
sleep 3

DEBIAN_FRONTEND='noninteractive' apt-get -q -y -o Dpkg::Options::='--force-confdef' -o Dpkg::Options::='--force-confold' dist-upgrade
sleep 3

curl -X POST -H 'Content-type: application/json' --data '{"text":"install prerequisite packages"}' $WEBHOOK_URL

## Install prerequisite packages (nginx, certbot, python3, curl, make, zip, ..... ) 
echo "Install prerequisite packages (nginx, certbot, python3, curl, make, zip, ..... ) "

sudo apt-get update -y -q  && sudo apt-get -y -q install nginx certbot python3-certbot-nginx fail2ban
sleep 3
sudo apt-get update -y -q  && sudo apt-get -y -q install wget zip unzip curl lsb-release make cowsay s3cmd
sleep 3
sudo apt-get update -y -q  && sudo apt-get -y -q install software-properties-common openssh-server openssh-client  
sleep  3

# Clean ----
echo "Clean -----"

curl -X POST -H 'Content-type: application/json' --data '{"text":"install prerequisite packages"}' $WEBHOOK_URL
sudo apt-get update -y -q

sudo chmod -R 2755 /var/www
sudo chown -R www-data:www-data /var/www
sudo rm -f /etc/nginx/sites-*/default
sudo rm -rf /var/www/html

sudo apt-get clean -y -q
sudo apt-get autoremove -y -q

# Reboot ---
echo "Reboot ---"
curl -X POST -H 'Content-type: application/json' --data '{"text":"Check Reboot"}' $WEBHOOK_URL

if [[ $is_reboot_enabled == true ]]
then

    curl -X POST -H 'Content-type: application/json' --data '{"text":"Start Reboot"}' $WEBHOOK_URL
    reboot
    curl -X POST -H 'Content-type: application/json' --data '{"text":"End Reboot"}' $WEBHOOK_URL

fi

curl -X POST -H 'Content-type: application/json' --data '{"text":"End cloud init"}' $WEBHOOK_URL

echo "=>>>>>>>>>>>>>>>>>>>>>>>>>>> End cloud init <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<="
