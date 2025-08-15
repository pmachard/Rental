# Étape 1 : construire l'application
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /app

# Copier les fichiers csproj et restaurer les dépendances
COPY *.csproj .
RUN dotnet restore

# Copier le reste des fichiers et publier
COPY . .
RUN dotnet publish -c Release -o out

# Étape 2 : créer l'image finale
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview
WORKDIR /app
COPY --from=build /app/out .

# Exposer le port de l'API
EXPOSE 5000

# Lancer l'application
ENTRYPOINT ["dotnet", "/app/Contracts.dll"]