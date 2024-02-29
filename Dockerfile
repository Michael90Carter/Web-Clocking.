FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1809 AS build
WORKDIR /src
COPY ["Trial/Trial.csproj", "Trial/"]
RUN dotnet restore "Trial/Trial.csproj"
COPY . .
WORKDIR "/src/Trial"
RUN dotnet build "Trial.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trial.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trial.dll"]
