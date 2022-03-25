# Porto API
 API feita para processo seletivo usando .NET

# Como rodar
<p>Para rodar a aplicação, conecte-se ao servidor SQL Express em sua máquina e altere a ConncetionString tanto no arquivo appsettings.json quanto no PortoContext na camada de Infra </p>
```bash

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

# Assimm a aplicação deverá abrir na porta 5001 do https
# Utilizando o Swagger podemos testar todas as funções em https://localhost:5001/swagger/index.html

#Se tudo ocorrer bem deverá aparecer uma tela assim:

# Instale as dependências
$ npm install

# Execute a aplicação em modo de desenvolvimento
$ npm run start

# A aplicação será aberta na porta:3000 - acesse http://localhost:3000

```

![image](https://user-images.githubusercontent.com/75286020/160028349-d76a7e58-d3ff-4746-b6d0-2410af3f1437.png)
