#dotnet nuget config set repositoryPath /tmp --configfile nuget.config

dotnet clean
dotnet build

cp ./nugets/* ./tests/TestContainer.Net8
cp ./nugets/* ./tests/TestContainer.Net9
#docker build -t localhost/test-container:net8 ./tests/TestContainer.Net8
#docker build -t localhost/test-container:net9 ./tests/TestContainer.Net9
dotnet test

#nuget config -set repositoryPath= -configfile nuget.config
