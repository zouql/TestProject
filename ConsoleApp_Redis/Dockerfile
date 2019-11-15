#FROM ubuntu:14.04
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim
ENV TZ=Asia/Shanghai
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
RUN sed -i "s@http://deb.debian.org@http://mirrors.huaweicloud.com@g" /etc/apt/sources.list \
        && sed -i "s@http://security.debian.org@http://mirrors.huaweicloud.com@g" /etc/apt/sources.list \
        && apt-get update \
        && apt-get install -y --no-install-recommends redis-server


RUN mkdir /data && chown redis:redis /data

#RUN ["/bin/bash", "-c", "sudo redis-server /etc/redis/redis.conf"]

VOLUME /data
WORKDIR /

EXPOSE 6379
#ENTRYPOINT [ "redis-server","etc/redis/redis.conf"]
CMD []

#https://registry.docker-cn.com/
#docker build  -t redis:v1 .
#docker run -p 6378:6379 -d redis:v1 redis-server --appendonly yes
#docker stop $(docker ps -a -q)
#docker rm $(docker ps -a -q)
#docker ps -a
#docker exec -it  2797f743d83d /bin/bash
#docker run -i -t -d redis:v1 /bin/bash

#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
#WORKDIR /src
#COPY ["ConsoleApp_Redis/ConsoleApp_Redis.csproj", "ConsoleApp_Redis/"]
#RUN dotnet restore "ConsoleApp_Redis/ConsoleApp_Redis.csproj"
#COPY . .
#WORKDIR "/src/ConsoleApp_Redis"
#RUN dotnet build "ConsoleApp_Redis.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "ConsoleApp_Redis.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ConsoleApp_Redis.dll"]


