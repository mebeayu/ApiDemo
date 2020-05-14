FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 8021

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ApiDemo/ApiDemo.csproj", "ApiDemo/"]
RUN dotnet restore "ApiDemo/ApiDemo.csproj"
COPY . .
WORKDIR "/src/ApiDemo"
RUN dotnet build "ApiDemo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ApiDemo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ApiDemo.dll"]