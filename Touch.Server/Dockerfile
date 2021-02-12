FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
EXPOSE 12345
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Touch.Server/Touch.Server.csproj", "Touch.Server/"]
COPY ["Touch.Shared/Touch.Shared.csproj", "Touch.Shared/"]
RUN dotnet restore "Touch.Server/Touch.Server.csproj"
COPY . .
WORKDIR "/src/Touch.Server"
RUN dotnet build "Touch.Server.csproj" -c Debug -o /app

FROM build AS publish
RUN dotnet publish "Touch.Server.csproj" -c Debug -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Touch.Server.dll"]