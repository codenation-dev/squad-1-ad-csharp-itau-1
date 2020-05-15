# ItaLog - Central de Erros - Squad 1

## O Desafio

Em projetos modernos é cada vez mais comum o uso de arquiteturas baseadas em serviços ou microsserviços. Nestes ambientes complexos, erros podem surgir em diferentes camadas da aplicação (backend, frontend, mobile, desktop) e mesmo em serviços distintos. Desta forma, é muito importante que os desenvolvedores possam centralizar todos os registros de erros em um local, de onde podem monitorar e tomar decisões mais acertadas. Neste projeto vamos implementar um sistema para centralizar registros de erros de aplicações.

## Requisitos

### Backend - API
- criar endpoints para serem usados pelo frontend da aplicação
- criar um endpoint que será usado para gravar os logs de erro em um banco de dados relacional
a API deve ser segura, permitindo acesso apenas com um token de autenticação válido

## Tecnologias utilizadas
- [.Net Core](https://dotnet.microsoft.com/download/dotnet-core/3.1) - versão 3.1.3
- [Entity Framework](https://docs.microsoft.com/pt-br/ef/) - versão 3.1.3
- [Auto Mapper](https://github.com/AutoMapper/AutoMapper) - versão 9.0.0
- [Identity](https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/identity?view=aspnetcore-3.1&tabs=visual-studio) - versão 2.2.0
- [MailKit](https://github.com/jstedfast/MailKit) - versão 2.6.0
- [Moq](https://github.com/moq/moq4) - versão 4.14.1
- [xUnit](https://xunit.net/) - versão 2.4.1
- [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle) - versão 5.4.1


## O Squad

Trabalho desenvolvido por:

- Afonso | [@afonsohsc](https://github.com/afonsohsc)

- André | [@andre1gauna](https://github.com/andre1gauna)

- Brunna | [@BrunnaMaiaradaSilva](https://github.com/BrunnaMaiaradaSilva)

- Bruno | [@brunoritter123](https://github.com/brunoritter123)

- Carlos | [@Cadulox](https://github.com/Cadulox)

## Ambiente de desenvolvimento

### Servidor de desenvolvimento
Execute `dotnet watch run --project ./ItaLog/ItaLog.Api/` para iniciar o servidor. Navegue em `http://localhost:5000/`. O aplicativo será recarregado automaticamente se você alterar qualquer um dos arquivos de origem.

### Criando migrations
Execute `dotnet ef migrations add "nome-da-migration" --project ./ItaLog/ItaLog.Data/ --startup-project ./ItaLog/ItaLog.API/` para gerar uma nova *migration* do banco de dados.

### Atualizando o banco de dados
Execute `dotnet ef database update --project ./ItaLog/ItaLog.Data/ --startup-project ./ItaLog/ItaLog.API/` atulizando o banco de banco de dados com as migrations do projeto.

### Build
Execute `dotnet build ./ItaLog/ItaLog.sln` para contruir os executaveis do projeto.

### Teste unitários
Execute `dotnet test ./ItaLog/ItaLog.sln` para iniciar os testes unitários via [xUnit](https://xunit.net/).
