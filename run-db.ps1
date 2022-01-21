$Folder = '__azurite'

if (-not (Test-Path -Path $Folder)) {mkdir __azurite}
cd __azurite && azurite