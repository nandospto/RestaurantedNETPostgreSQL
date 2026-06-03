# Projeto Restaurante Guias

Tema: Programação de uma API com .NET + PostgreSQL

Biblioteca: .NET 10

---

Iniciamos o projeto inicializando o .Net na pasta raiz:

~~~cmd
dotnet new webapi
~~~

Caso não haja uma pasta do projeto, podemos iniciarlizar usando:

~~~cmd
dotnet new webapi -n nomedoprojeto
~~~

No caso desse projeto, utilizamos o nome da pasta como `backend`.

A API vai ser montada com um projetinho pequeno de weatherforecaster imbutido no Program.cs. Podemos apagar essa parte e deixar o código limpo:

~~~csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

// Área da produção:
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


// App funcionando
app.Run();

~~~

Criaremos agora uma pasta de Database, Controllers e Models onde ficarão a ligação com o framework do postgresql, os controles e o modelos das tabelas. Adicionando também a linha `builder.Services.AddControllers();` no Program.cs abaixo do `builder.Services.AddOpenApi();`. Adicionamos também `app.MapControllers();` antes do `app.run();` para mapear os controllers do backend.Controllers.

As pastas servem para melhorar a organização do código.

Vamos agora adicionar as bibliotecas necessárias através do NuGet.

Nosso projeto tem as seguintes packages instaladas:

- Microsoft.AspNetCore.OpenApi Version 10.0.8 -> .Net Core
- Microsoft.EntityFrameworkCore Version 10.0.0 -> ORM para a ligação com a DB
- Microsoft.EntityFrameworkCore.Tools Version 10.0.0 -> Ferramentas de integração
- Npgsql.EntityFrameworkCore.PostgreSQL Version 10.0.0 -> Ferramentas da DB do postgreSQL

Agora aplicamos o `dotnet build` para compilar o projeto e vermos se há erros.

Com o projeto funcionando, temos que integrar o postgreSQL. Segundo a própria documentação do Npgsql, temos que usar:

~~~csharp
var connectionString = "Host=myserver;Username=mylogin;Password=mypass;Database=mydatabase";
await using var dataSource = NpgsqlDataSource.Create(connectionString);
~~~

Porém, esse método é bastante inseguro. Para contornar isso, podemos usar o appsettings.json do próprio projeto, criando uma Connection String diretamente nele e a acessando.

Na pasta Data, criamos o arquivo `AppDbContext.cs` e adicionamos o seguinte código:

~~~csharp
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class AppDbContext : DbContext // Adionando a herança do EntityFrameworkCore
    {
        public AppDbContext(DbContextOptions options) : base(options){} // Cria a função pública para acesso ao options e ao AppDbContext

        // Aqui entram os DbSet<MyEntity> MyEntity que são as tabelas do banco de dados, caso não hajam.
    }
}
~~~

No appsettings.json, temos que adicionar a seguinte linha após o `"AllowedHosts": "*"`:

~~~json
  "ConnectionStrings": {
    "AppDBConnectionString": "Server=localhost;Database=MyAppDb;UserId=userid;Password=password;"
  }
~~~

Assim temos uma string de conexão, mas ainda temos que acessá-la. No program.cs, podemos adicionar uma variável e utilizar o próprio options do c#. Adicionamos então a variável `var ConnectionString` e a ligamos ao appsettings através do configuration do builder.

~~~csharp
// Variável de conexão com o banco de dados pega no appsettings.json pela chave AppDBConnectionString
var ConnectionString = builder.Configuration.GetConnectionString("AppDBConnectionString");
// Ligação com o framework do Npgsql utilizando o ConnectionString
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(ConnectionString));
~~~