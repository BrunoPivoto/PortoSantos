# Porto API
 API feita para processo seletivo usando .NET

# Como rodar
<p>Para rodar a aplicação, conecte-se ao servidor SQL Express em sua máquina e altere a ConncetionString tanto no arquivo appsettings.json quanto no PortoContext na camada de Infra </p>

# Acesse a pasta do projeto no seu terminal/cmd
$ cd Porto.Infra

# Execute os comandos para migrar o Banco de Dados
$ dotnet tool install --global dotnet-ef 
$ dotnet ef migrations add InitialMigration
$ dotnet ef database update

# Vá para a pasta da aplicação Api
$ cd Porto.API

# Exceute os comandos para iniciar a aplicação
$ dotnet build
$ dotnet run

# Assim a aplicação deverá abrir na porta 5001 do https
# Utilizando o Swagger podemos testar todas as funções em: 
https://localhost:5001/swagger/index.html

Se tudo ocorrer bem deverá aparecer uma tela assim:
---
![tela](https://user-images.githubusercontent.com/75286020/160145237-52a2c3bd-8888-4b35-b6a8-08882bbc58fc.png)
