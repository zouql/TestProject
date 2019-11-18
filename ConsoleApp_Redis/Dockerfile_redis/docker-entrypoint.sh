#!/bin/sh

exec redis-server

exec dotnet ConsoleApp_Redis.dll
