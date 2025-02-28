FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 7035
ENV ASPNETCORE_URLS "http://+:7035"
LABEL run="docker run -d -p 7035:7035 gvipin/carpriceapi"

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["CarPriceApi/CarPriceApi.csproj", "CarPriceApi/"]
RUN dotnet restore "CarPriceApi/CarPriceApi.csproj"
COPY . .
WORKDIR "/src/CarPriceApi"
RUN dotnet publish "CarPriceApi.csproj" -c Release -o /app/carpriceapi

FROM base AS final
WORKDIR /app
COPY --from=build /app/carpriceapi .
ENTRYPOINT ["dotnet", "CarPriceApi.dll"]