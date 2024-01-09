*** Comandos config ***
-- dotnet ef migrations add EstruturaInicial
-- dotnet ef database update

-- dotnet ef dbcontext scaffold "host-localhost;database=aula_youtube-pedido_produtos;userid=danilo"
Microsoft.EntityFrameworkCore.SqlServer -o Models -f -c ContextoLoja1

--dotnet tool install -g dotnet-aspnet-codegenerator

-- dotnet aspnet-codegenerator controller -name AdministradoresController -m Cliente -dc
ContextoCms --relativeFoldePath Controllers --useDefaultlayout

-- dotnet add package Microsoft.EntityFrameworkCore --version 7.0.14

-- dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.14

-- dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.14

-- dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.14

-- dotnet add package Newtonsoft.Json --version 13.0.3

-- dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 7.0.11