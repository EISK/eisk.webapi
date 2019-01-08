echo $$$$$$$$$$$$$$$$$$$$ installing template {nuspec - package id / path} 
dotnet new -i  ..\Eisk.WebApi.TemplatePack\bin\Debug\templates\*.nupkg

rmdir .\dnn-local-template-render /s /q
mkdir dnn-local-template-render
cd dnn-local-template-render

echo $$$$$$$$$$$$$$$$$$$$ create content from template {template.json - shortname}
dotnet new eiskwebapi -n App

echo $$$$$$$$$$$$$$$$$$$$ unstalling template {nuspec - package id / template.json - identity }
dotnet new -u Eisk.WebApi