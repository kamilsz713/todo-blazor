FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /app

COPY . .

WORKDIR /app/Todo.Frontend

RUN dotnet restore
RUN dotnet publish -c Release -o /out

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /out/Todo.Frontend/dist .
COPY ./Todo.Frontend/conf/nginx.conf /etc/nginx/nginx.conf