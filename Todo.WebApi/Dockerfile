FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Todo.WebApi/Todo.WebApi.csproj", "Todo.WebApi/"]
RUN dotnet restore "Todo.WebApi/Todo.WebApi.csproj"
COPY . .
WORKDIR "/src/Todo.WebApi"
RUN dotnet build "Todo.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Todo.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todo.WebApi.dll"]
