if (Test-Path -Path dist) {
    Write-Output "------->Cleaning up dist
"
    Remove-Item -recurse -force dist
}
Write-Output "------->building react app...
"
cd app && npm run build
cd ..

Write-Output "------->Publishing api to dist...
"

cd api\src && dotnet publish -o ..\..\dist

Write-Output "------->Published about to run exe
"
$list=$(dotnet user-secrets list)

$password=$($list -match "Email:Password" -replace "Email:Password = ")
$email=$($list -match "Email:Address" -replace "Email:Address = ")

cd ..\..

$Env:Email:Password = $password
$Env:Email:Address = $email

cd dist && .\wedding-api.exe
cd ..