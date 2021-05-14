FROM alpine:3.13

ENV TERRAFORM_VERSION=0.14.11

WORKDIR /work

RUN apk update && \
    apk add --no-cache curl jq python3 bash \
    ca-certificates git openssl unzip \
    wget ansible openssh-client openssh-server make && \
    cd /tmp && \
    wget https://releases.hashicorp.com/terraform/${TERRAFORM_VERSION}/terraform_${TERRAFORM_VERSION}_linux_amd64.zip && \
    unzip terraform_${TERRAFORM_VERSION}_linux_amd64.zip -d /usr/bin && \
    rm -rf /tmp/* && \
    rm -rf /var/cache/apk/* && \
    rm -rf /var/tmp/*

ENTRYPOINT ["/bin/bash"]