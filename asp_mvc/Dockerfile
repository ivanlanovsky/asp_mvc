#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["asp_mvc/asp_mvc.csproj", "asp_mvc/"]
RUN dotnet restore "asp_mvc/asp_mvc.csproj"
COPY . .
WORKDIR "/src/asp_mvc"
RUN dotnet build "asp_mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "asp_mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "asp_mvc.dll"]