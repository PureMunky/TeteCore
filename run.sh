# stop existing container
docker stop tete-core-app

# remove existing container
docker rm tete-core-app

# clean the dotnet build files
dotnet clean

# build a new version of core
docker build -t tete-core .

# run core app
docker run -dit --name tete-core-app -p 80:80 tete-core

# ./run.sh