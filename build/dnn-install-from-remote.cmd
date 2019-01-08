echo $$$$$$$$$$$$$$$$$$$$ installing template {nuspec - package id / path} 
dotnet new -i  Eisk.WebApi

rmdir .\dnn-remote-template-render /s /q
mkdir dnn-remote-template-render
cd dnn-remote-template-render

echo $$$$$$$$$$$$$$$$$$$$ create content from template {template.json - shortname}
dotnet new eiskwebapi -n App

echo $$$$$$$$$$$$$$$$$$$$ unstalling template {nuspec - package id / template.json - identity }
dotnet new -u Eisk.WebApi