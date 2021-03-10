# asp_mvc

##How to host it on heroku

*italic*building project - *italic* ###dotnet publish -c Release
then go to ###bin\Release\net5.0\publish
and run following:
###heroku container:login
###docker build -t |heroku application there|
###docker tag |appname| registry.heroku.com/|appname|/web
###docker push registry.heroku.com/|appname|/web
###heroku container:release web --app |appname|
