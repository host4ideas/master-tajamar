#LA IMAGEN A DESCARGAR
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#ESTA ES LA IMAGEN QUE NECESITA EL COMPILADOR DE NET
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY *.csproj ./
#DESCARGAR TODOS LOS NUGET DEL PROYECTO
RUN dotnet restore 
COPY . .
WORKDIR "/src/MvcDockerComics"
#COMPILA EL PROYECTO EN LA IMAGEN DE DOCKER
RUN dotnet build "/src/MvcDockerComics.csproj" -c Release -o /app/build

#CREAMOS UN PUNTO PARA PUBLICAR LA IMAGEN EN EL DOCKER
FROM build AS publish
RUN dotnet publish "/src/MvcDockerComics.csproj" -c Release -o /app/publish

#COPIA EL PROYECTO PUBLICADO DENTRO DE LA APP PARA SU EJECUCION
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MvcDockerComics.dll"]