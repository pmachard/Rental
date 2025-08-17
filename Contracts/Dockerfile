# Étape 1 : construire l'application
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /app

# Copier les fichiers csproj et restaurer les dépendances
COPY *.csproj .
RUN dotnet restore

# Copier le reste des fichiers et publier
COPY Contracts.csproj ./
RUN dotnet restore ./Contracts.csproj

COPY . ./
RUN dotnet publish ./Contracts.csproj -c Release -o /app/out

# Étape 2 : créer l'image finale
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview
WORKDIR /app
COPY --from=build /app/out .

# Exposer le port de l'API
EXPOSE 8080

# Lancer l'application
ENTRYPOINT ["dotnet", "Contracts.dll"]