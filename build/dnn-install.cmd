echo $$$$$$$$$$$$$$$$$$$$ installing template {nuspec - package id / path} 
dotnet new -i  ..\Eisk.WebApi.TemplatePack\bin\Debug\templates\Eisk.WebApi.1.0.0.nupkg

rmdir .\dnn-template-render /s /q
mkdir dnn-template-render
cd dnn-template-render

echo $$$$$$$$$$$$$$$$$$$$ create content from template {template.json - shortname}
dotnet new eiskwebapi -n App

echo $$$$$$$$$$$$$$$$$$$$ unstalling template {nuspec - package id / template.json - identity }
dotnet new -u Eisk.WebApi