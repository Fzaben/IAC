docker build -t fzaben/devops .
docker run -it -v `pwd -W`:/work fzaben/devops

update 