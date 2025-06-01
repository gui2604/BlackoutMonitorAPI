# -------------------------------
# Etapa 1: Build da aplicação
# -------------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos do projeto
COPY *.csproj .
RUN dotnet restore

# Copia o restante do código
COPY . .
RUN dotnet publish -c Release -o /app/publish

# -------------------------------
# Etapa 2: Runtime (imagem leve)
# -------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia a saída da publicação
COPY --from=build /app/publish .

# Define a porta exposta no container
EXPOSE 8080

# Variável de ambiente opcional (para modo dev)
ENV ASPNETCORE_URLS=http://+:8080

# Executa a aplicação
ENTRYPOINT ["dotnet", "BlackoutMonitorAPI.dll"]
