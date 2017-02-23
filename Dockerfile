FROM microsoft/dotnet:latest

ENV ASPNETCORE_ENVIRONMENT="AWS"

COPY . /app

WORKDIR /app

RUN ["dotnet", "restore"]

RUN ["dotnet", "build"]

EXPOSE 5000

CMD ["dotnet", "run", "--server.urls", "http://*:5000"]
