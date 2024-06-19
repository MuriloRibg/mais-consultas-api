# API more consultas ![Bafge](https://img.shields.io/badge/Version-1.0.0-green) ![Bafge](https://img.shields.io/badge/.Net-8.0.100-blue)

API .Net 8 usando ORM Entity Framework e com arquitetura MVC.


## Autores

- [@MuriloRibg](https://github.com/muriloribg)
- [@Arthurhardman](https://github.com/arthurhardman)
- [@Emanueljsweb](https://github.com/https://github.com/emanueljsweb)
- [@EricEller22](https://github.com/EricEller22)
- [@Pedroohferreira](https://github.com/pedroohferreira)



## Rodando localmente

É necessário definir a string de conexão no arquivo appsettings.Development

```bash
  "ConnectionStrings": {
    "MySql": "server=localhost;port=3306;database={SeuDB};uid={SeuUsuario};pwd={SuaSenha}"
  }
```

Comando para criar e executar as migrations.

```bash
  dotnet ef migrations add InitialCreate
  dotnet ef database update
```
