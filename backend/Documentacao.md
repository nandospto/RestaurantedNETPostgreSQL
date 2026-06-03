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

Assim temos uma string de conexão. O `Server` mostra o server hospedado do banco de dados, `Database` diz respeito ao nome do banco de dados, `UserId` e `Password` são o usuário e senha do banco.

OBS: O banco deve ser criado com o nome referenciado na Connection String.

 Ainda temos que acessar a String. No program.cs, podemos adicionar uma variável e utilizar o próprio options do c#. Adicionamos então a variável `var ConnectionString` e a ligamos ao appsettings através do configuration do builder. Tudo isso antes do App com `var app = builder.Build();`,

~~~csharp
// Variável de conexão com o banco de dados pega no appsettings.json pela chave AppDBConnectionString
var ConnectionString = builder.Configuration.GetConnectionString("AppDBConnectionString");
// Ligação com o framework do Npgsql utilizando o ConnectionString
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(ConnectionString));
~~~

Com esse passo já podemos criar as tabelas do banco de dados ou exportá-las caso o banco de dados já exista. Como meu projeto é um projeto que se iniciou do zero, o banco de dados está vazio.

Iniciamos adicionando as tabelas no AppDbContext.cs:

~~~csharp
public DbSet<Clientes> Clientes {get; set;}
public DbSet<Pedidos> Pedidos {get; set;}
~~~

Logo após criamos as entidades das tabelas na pasta Models. Isso server apenas para deixar o código mais organizado.

Temos aqui dois arquivos: Cliente.cs e Pedidos.cs.

Cliente:
~~~csharp
using System.ComponentModel.DataAnnotations; // Para que a chave [Key] funcione

namespace backend.Models
{
    public class Clientes
    {
        [Key] // Chave primária, mas pode ser ignorada se exister uma variável chamada Id
        public int ClienteId {get; set;}
        public string Nome {get; set;} = null!;
        public string? Email {get; set;}
        public string? Telefone {get; set;}

        public List<Pedidos> Pedidos {get; set;} = new List<Pedidos>(); // Lista de pedidos associados ao cliente, instanciando uma relação de 1:N
    }
}
~~~

Pedidos:
~~~csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Para que a chave de [ForeignKey] (chave estrangeira)

namespace backend.Models
{
    public class Pedidos
    {
        [Key]
        public int PedidoId {get; set;}
        public string? Descricao {get; set;}

        [ForeignKey(nameof(ClienteId))] // Chave estrangeira referenciando a variável ClienteId da classe Clientes
        public int ClienteId {get; set;}  // Inicialização da variável ClienteId para a chave estrangeira
        public Clientes Clientes {get; set;} = null!; // Instância da classe Clientes da relação N:1
    
    }
}
~~~

Se tudo estiver correto, podemos inicializar a criação do banco usando:

~~~cmd
dotnet build
dotnet ef migrations add NomedaMigration
~~~

Sempre é bom rodar `dotnet build` para verificar quaisquer erros com a API.

O `dotnet ef migrations add NomedaMigration` serve para transformar o código de C# para PostgreSQL. Cada classe referenciada no AppDbContext.cs e criada no Models será instanciada usando as regras do PostgreSQL. OBS: Toda migration deve ter um nome único.

Se tudo ocorrer corretamente, ao olhar o banco de dados veremos três tabelas. Duas relacionadas e uma sem relacionamento que serve para guardar os dados de cada migration.