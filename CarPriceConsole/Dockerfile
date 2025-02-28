FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 7036 
ENV ASPNETCORE_URLS "http://+:7036"
LABEL run="docker run -d -p 7036:7036 gvipin/carpriceconsole"

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["CarPriceConsole/CarPriceConsole.csproj", "CarPriceConsole/"]
RUN dotnet restore "CarPriceConsole/CarPriceConsole.csproj"
COPY . .
WORKDIR "/src/CarPriceConsole"
RUN dotnet publish "CarPriceConsole.csproj" -c Release -o /app/carpriceconsole

FROM base AS final
WORKDIR /app
COPY --from=build /app/carpriceconsole .
ENTRYPOINT ["dotnet", "CarPriceConsole.dll"]