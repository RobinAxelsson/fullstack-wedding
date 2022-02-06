    Write-Output "------->Resetting dist
"
if (Test-Path -Path dist) {
    Remove-Item -recurse -force dist
}
Write-Output "------->building react app...
"
cd app && npm run build
cd ..

Write-Output "------->Publishing api to dist...
"

cd api\src && dotnet publish -o ..\..\dist

$list=$(dotnet user-secrets list)

$password=$($list -match "Email:Password" -replace "Email:Password = ")
$email=$($list -match "Email:Address" -replace "Email:Address = ")

cd ..\..

echo "------->Moving build
"

if (-Not $(Test-Path -Path dist\wwwroot)) {
    Write-Output Adding wwwroot
    mkdir dist\wwwroot
}

Copy-Item app\build\* -Destination dist\wwwroot -Recurse

Write-Output "------->Published about to run exe
"

$Env:Email:Password = $password
$Env:Email:Address = $email

cd dist && .\wedding-api.exe
cd ..