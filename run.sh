# stop existing container
docker stop tete-core-app

# remove existing container
docker rm tete-core-app

# build a new version of core
docker build -t tete-core ./core

# run core app
docker run -dit --name tete-core-app -p 80:80 tete-core

# ./run.sh