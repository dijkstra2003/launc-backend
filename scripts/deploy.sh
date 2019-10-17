echo "$DOCKER_PASSWORD" | docker login -u "$DOCKER_USERNAME" --password-stdin
docker build -t launc .
docker images
docker tag launc:$1 $DOCKER_USERNAME/launc-backend
docker push $DOCKER_USERNAME/launc-backend
