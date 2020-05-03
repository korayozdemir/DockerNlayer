FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
WORKDIR /app
#COPY ./DockerNlayer.Test/*.csproj ./DockerNlayer.Test/
COPY ./DockerNlayer.Core/*.csproj ./DockerNlayer.Core/
COPY ./DockerNlayer.Entity/*.csproj ./DockerNlayer.Entity/
COPY ./DockerNlayer.DTO/*.csproj ./DockerNlayer.DTO/
COPY ./DockerNlayer.DAL/*.csproj ./DockerNlayer.DAL/
COPY ./DockerNlayer.Mapping/*.csproj ./DockerNlayer.Mapping/
COPY ./DockerNlayer.BLL/*.csproj ./DockerNlayer.BLL/
COPY ./DockerNlayer.WebUI/*.csproj ./DockerNlayer.WebUI/
COPY *.sln .
RUN dotnet restore
COPY . .
#RUN dotnet test ./DockerNlayer.Test/*.csproj
RUN dotnet publish ./DockerNlayer.WebUI/*.csproj -o /publish/
FROM mcr.microsoft.com/dotnet/core/runtime:3.1
WORKDIR /app
COPY --from=build /publish .
ENV ASPNETCORE_URLS="http://*:5000"
ENTRYPOINT ["dotnet","DockerNlayer.WebUI.dll"]
