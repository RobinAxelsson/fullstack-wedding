$password = $args[0]
dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p $password
dotnet dev-certs https --trust

Write-Host added cert to $env:USERPROFILE\.aspnet\https