


update values inside terraform
<!-- 
SSH_USER=user
SSH_PORT=2222
PRIVATE_KEY_PATH=/work/.ssh/id_rsa
REMOTE_SERVER=devops.demo.drah.im 
-->

make update-user-data
make init
make plan
make apply

# discard changes in user-data.sh file
git checkout user-data.sh