FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY dist /app
WORKDIR /app
EXPOSE 80/tcp
EXPOSE 443/tcp
ENTRYPOINT ["dotnet", "dotnetMidtermStarter.dll"]
