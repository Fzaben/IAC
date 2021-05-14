# pull base image
FROM mcr.microsoft.com/dotnet/sdk:5.0-focal

RUN apt-get -y update
RUN curl -sL https://deb.nodesource.com/setup_12.x 
RUN apt-get install -y nodejs npm s3cmd openssh-client
RUN npm install -g yarn
WORKDIR /work

# ENTRYPOINT ["/bin/bash"]