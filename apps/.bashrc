#!/bin/bash
SSH_PORT=2222
email=fzaben@aqwas.sa
IP=207.154.235.79
SSH_USER=do
main_domain=devops.demo.drah.im

server="$SSH_USER@$IP"
DOMAIN=$1$main_domain

solution_name='DevOps'
project_root_path="."
backend_path="aspnet-core"
pvt_key_path=~/Workspace/devops/IAC/.ssh/id_rsa
project_path=$backend_path'/src'
unpackage='sudo tar vzxf'

source ci-scripts/.aliasrc

# deploy Apps
init_deploy_apps () {
    mkdir-deployment-directories && \
    change-permission && \
    init_deploy_host && \
    sleep 3 && \
    init_deploy_reactjs && \
    change-permission
}

deploy_apps () {
    publish_host && \
    restart-host-service
    publish_reactjs && \
    change-permission && \
    restart-nginx
}