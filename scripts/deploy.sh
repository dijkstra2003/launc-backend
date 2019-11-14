echo "$DOCKER_PASSWORD" | docker login -u "$DOCKER_USERNAME" --password-stdin
docker build -t launc .
docker images
docker tag launc:latest $DOCKER_USERNAME/launc-backend:$1
docker push $DOCKER_USERNAME/launc-backend
