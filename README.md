# Projeto CRUD API com .NET e Angular

## Descrição

Este projeto consiste em uma API REST desenvolvida em .NET integrada com um frontend em Angular. A aplicação permite realizar operações CRUD (Create, Read, Update, Delete) de produtos.

## Pré-requisitos

- Node.js
- PostgreSQL
- .NET SDK
- Angular CLI

## Como executar

### Backend (API)

1. Clone o repositório:
/// git clone https://github.com/usuario/nome-do-repositorio.git

2. Acesse a pasta da API:
/// cd nome-do-repositorio/CrudApi

3. Execute a atualização do banco de dados:
/// dotnet ef database update

4. Inicie a API:
/// dotnet run

A API estará disponível em: http://localhost:5000

### Frontend (Angular)

1. Acesse a pasta do projeto Angular:
/// cd ../AppAngular

2. Instale as dependências:
/// npm install

3. Inicie a aplicação Angular:
/// ng serve

4. Acesse a aplicação no navegador:
/// http://localhost:4200/Produtos

## Possíveis erros

### Erro de conexão com o banco de dados
Verifique se o PostgreSQL está em execução e se as credenciais no arquivo de configuração estão corretas.

### Erro ao executar migrations
Certifique-se de que o EF Core está instalado globalmente ou no projeto:
/// dotnet tool install --global dotnet-ef

### Erro de porta em uso
Caso a porta já esteja em uso, você pode especificar uma porta diferente:
- Para a API: /// dotnet run --urls=http://localhost:PORTA
- Para o Angular: /// ng serve --port PORTA

### Erro de módulos não encontrados
Execute /// npm install novamente para garantir que todas as dependências estejam instaladas corretamente.
