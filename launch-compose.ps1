$guid="826320d3-da29-4eb1-9d12-9417062f4bd0"
$filepath=$env:APPDATA + "\Microsoft\UserSecrets\" + $guid + "\secrets.json"
echo $filepath
$config=Get-Content -Path $filepath | ConvertFrom-Json

$env:EmailAddress=$config."Email:Address"
$env:EmailPassword=$config."Email:Password"
$env:EmailSmtpClient=$config."Email:SmtpClient"
$env:ConnectionString=$config.ConnectionString
$env:CertPassword=$config.CertPassword

docker compose up
docker compose down