#!/bin/bash
DOCKER_ENV=''
DOCKER_TAG=''

case "$TRAVIS_BRANCH" in
  "master")
    DOCKER_ENV=production
    DOCKER_TAG=latest
    ;;
  "develop")
    DOCKER_ENV=development
    DOCKER_TAG=dev
    ;;    
esac

case "$BITBUCKET_BRANCH" in
  "master")
    DOCKER_ENV=production
    DOCKER_TAG=latest
    ;;
  "develop")
    DOCKER_ENV=development
    DOCKER_TAG=dev
    ;;    
esac

docker login $DOCKER_REGISTRY -u $DOCKER_USERNAME -p $DOCKER_PASSWORD

docker build -f ./src/Fibon.Api/Dockerfile.$DOCKER_ENV -t fibon-api:$DOCKER_TAG --no-cache
docker build -f ./src/Fibon.Service/Dockerfile.$DOCKER_ENV -t fibon-service:$DOCKER_TAG --no-cache

docker tag fibon-api:$DOCKER_TAG $DOCKER_REGISTRY/fibon-api:$DOCKER_TAG
docker tag fibon-service:$DOCKER_TAG $DOCKER_REGISTRY/fibon-service:$DOCKER_TAG

docker push $DOCKER_REGISTRY/fibon-api:$DOCKER_TAG
docker push $DOCKER_REGISTRY/fibon-service:$DOCKER_TAG