FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HardCode.TestTask.ProductCatalog/HardCode.TestTask.ProductCatalog.csproj", "HardCode.TestTask.ProductCatalog/"]
RUN dotnet restore "HardCode.TestTask.ProductCatalog/HardCode.TestTask.ProductCatalog.csproj"
COPY . .
WORKDIR "/src/HardCode.TestTask.ProductCatalog"
RUN dotnet build "HardCode.TestTask.ProductCatalog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HardCode.TestTask.ProductCatalog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HardCode.TestTask.ProductCatalog.dll"]
