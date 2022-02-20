FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=https://+:80

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM node:alpine AS react
WORKDIR /react
COPY /app/package.json /app/yarn.lock ./
RUN yarn
COPY ./app ./
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS publish
COPY /api/src /wedding-app
WORKDIR /wedding-app
RUN dotnet publish -o dist

FROM base AS final
WORKDIR /app
COPY --from=publish /wedding-app/dist .
WORKDIR /app/wwwroot
COPY --from=react /react/build .
WORKDIR /app
ENTRYPOINT ["dotnet", "wedding-api.dll"]