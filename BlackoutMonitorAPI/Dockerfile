# -------------------------------
# Etapa 1: Build da aplica��o
# -------------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos do projeto
COPY *.csproj .
RUN dotnet restore

# Copia o restante do c�digo
COPY . .
RUN dotnet publish -c Release -o /app/publish

# -------------------------------
# Etapa 2: Runtime (imagem leve)
# -------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia a sa�da da publica��o
COPY --from=build /app/publish .

# Define a porta exposta no container
EXPOSE 8080

# Vari�vel de ambiente opcional (para modo dev)
ENV ASPNETCORE_URLS=http://+:8080
#ENV ASPNETCORE_ENVIRONMENT=Development


# Executa a aplica��o
ENTRYPOINT ["dotnet", "BlackoutMonitorAPI.dll"]
