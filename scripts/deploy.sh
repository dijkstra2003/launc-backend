echo "$DOCKER_PASSWORD" | docker login -u "$DOCKER_USERNAME" --password-stdin
docker build -t launc .
docker images

if [ $1 == "release" ]; then
    docker tag launc:latest $DOCKER_USERNAME/launc-backend:$1
else
    docker tag launc:latest $DOCKER_USERNAME/launc-backend:latest
    docker tag launc:latest $DOCKER_USERNAME/launc-backend:$1
fi

docker push $DOCKER_USERNAME/launc-backend
