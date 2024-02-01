*** Comandos config ***
-- dotnet ef migrations add EstruturaInicial
-- dotnet ef database update

-- dotnet ef dbcontext scaffold "host-localhost;database=aula_youtube-pedido_produtos;userid=danilo"
Microsoft.EntityFrameworkCore.SqlServer -o Models -f -c ContextoLoja1

--dotnet tool install -g dotnet-aspnet-codegenerator

-- dotnet aspnet-codegenerator controller -name AdministradoresController -m Cliente -dc ContextoCms --relativeFolderPath Controllers --useDefaultLayout

-- dotnet add package Microsoft.EntityFrameworkCore --version 7.0.14

-- dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.14

-- dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.14

-- dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.14

-- dotnet add package Newtonsoft.Json --version 13.0.3

-- dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 7.0.11

**** Configurando produção ****

wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

sudo apt update

sudo apt-cache dump | grep dotnet-sdk

sudo apt install apt-transport-https
sudo apt install dotnet-sdk-7.0

sudo apt install apt-transport-https
sudo apt install dotnet-runtime-7.0

sudo apt install nginx

sudo vim /etc/nginx/sites-available/default

proxy_pass no nginx

location some/path/ {
    proxy_pass https://localhos:5001;
}

sudo systemctl restart nginx

liberar porta 80 no EC2


dotnet tool install --global dotnet-ef
dotnet ef database update

