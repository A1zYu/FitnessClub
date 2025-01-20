FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/FitnessClub.Web/FitnessClub.Web.csproj", "src/FitnessClub.Web/"]
COPY ["src/FitnessClub.Application/FitnessClub.Application.csproj", "src/FitnessClub.Application/"]
COPY ["src/FitnessClub.Domain/FitnessClub.Domain.csproj", "src/FitnessClub.Domain/"]
COPY ["src/FitnessClub.Infrastructure/FitnessClub.Infrastructure.csproj", "src/FitnessClub.Infrastructure/"]
RUN dotnet restore "src/FitnessClub.Web/FitnessClub.Web.csproj"
COPY . .
WORKDIR "/src/src/FitnessClub.Web"
RUN dotnet build "FitnessClub.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FitnessClub.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FitnessClub.Web.dll"]
