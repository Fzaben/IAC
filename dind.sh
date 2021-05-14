#!/bin/bash

docker network create some-network
docker volume create some-docker-certs-ca
docker volume create some-docker-certs-client

docker run --privileged --name some-docker -d \
    --network some-network --network-alias docker \
    -e DOCKER_TLS_CERTDIR=/certs \
    -v some-docker-certs-ca:/certs/ca \
    -v some-docker-certs-client:/certs/client \
    docker:dind

    docker run --rm --network some-network \
        -e DOCKER_TLS_CERTDIR=/certs \
        -v some-docker-certs-ca:/certs/ca \
        -v some-docker-certs-client:/certs/client \
        docker:latest version

docker run -it --rm --network some-network \
    -e DOCKER_TLS_CERTDIR=/certs \
    -v some-docker-certs-client:/certs/client:ro \
    -v /var/run/docker.sock:/var/run/docker.sock \
    docker:latest sh
    
docker run --rm --network some-network \
    -e DOCKER_TLS_CERTDIR=/certs \
    -v some-docker-certs-client:/certs/client:ro \
    docker:latest info

docker run --rm -v /var/run/docker.sock:/var/run/docker.sock docker:latest version


##
docker run -p 8080:8080 -p 50000:50000 -v jenkins_home:/var/jenkins_home jenkins/jenkins:lts
