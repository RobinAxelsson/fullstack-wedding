FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 3000
EXPOSE 10002

ENV ASPNETCORE_URLS=http://+:3000
ENV Email:Address=Dockerfile-mail
ENV ASPNETCORE_ENVIRONMENT=Production
ENV Email:Password=dockerfilepass

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