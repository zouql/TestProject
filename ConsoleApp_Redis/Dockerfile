FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
ENV TZ=Asia/Shanghai
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
RUN sed -i "s@http://deb.debian.org@http://mirrors.huaweicloud.com@g" /etc/apt/sources.list \
        && sed -i "s@http://security.debian.org@http://mirrors.huaweicloud.com@g" /etc/apt/sources.list \
        && apt-get update \
        && apt-get install -y --no-install-recommends redis-server

RUN mkdir /data && chown redis:redis /data

COPY ConsoleApp_Redis/docker-entrypoint.sh /usr/local/bin/
ENTRYPOINT ["docker-entrypoint.sh"]

WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["ConsoleApp_Redis/ConsoleApp_Redis.csproj", "ConsoleApp_Redis/"]
RUN dotnet restore "ConsoleApp_Redis/ConsoleApp_Redis.csproj"
COPY . .
WORKDIR "/src/ConsoleApp_Redis"
RUN dotnet build "ConsoleApp_Redis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsoleApp_Redis.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

#ENTRYPOINT ["dotnet", "ConsoleApp_Redis.dll"]