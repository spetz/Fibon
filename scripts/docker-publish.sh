docker login -u $DOCKER_USERNAME -p $DOCKER_PASSWORD
docker tag fibon-api $DOCKER_USERNAME/fibon-api
docker tag fibon-service $DOCKER_USERNAME/fibon-service
docker push $DOCKER_USERNAME/fibon-api
docker push $DOCKER_USERNAME/fibon-service