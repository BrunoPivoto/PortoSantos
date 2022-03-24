# Porto API
 API feita para processo seletivo usando .NET

# Como rodar
<p>Para rodar a aplicação, conecte-se ao servidor SQL Express em sua máquina e altere a ConncetionString tanto no arquivo appsettings.json quanto no PortoContext na camada de Infra </p>
<p>Usando o prompt de comando navegue até a pasta do projeto</p>
<p>Entre na pasta Porto.Infra com o comando "cd Porto.Infra" e digite os seguintes comandos: </p>
<p>dotnet tool install --global dotnet-ef 
<p>dotnet ef migrations add InitialMigration
<p>dotnet ef database update
<p>Assim seu banco de dados será criado
<p>Dentro da pasta navegue até a primeira pasta com o comando "cd Porto.API</p>
<p>Execute o comando "dotnet build" e depois "dotnet run" </p>
<p>Assimm o aplicativo deverá abrir na porta 5001 do https</p>
<p>Utilizando o Swagger podemos testar todas as funções em https://localhost:5001/swagger/index.html</p>
