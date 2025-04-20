# Projeto CRUD API com .NET e Angular

## Descrição

Desenvolvi uma API .NET para um CRUD de produtos, com um frontend em Angular. Neste projeto, implementei uma interface e um repositório genérico, permitindo criar, ler, atualizar, e deletar produtos de forma simples e escalável. O uso do repositório genérico foi fundamental para abstrair operações de banco de dados e facilitar a manutenção do código.

## Pré-requisitos

- Node.js
- PostgreSQL
- .NET SDK
- Angular CLI

## Como executar

### Backend (API)

1. Clone o repositório:
```bash
git clone https://github.com/usuario/nome-do-repositorio.git
```

2. Acesse a pasta da API:
```bash
 cd nome-do-repositorio/CrudApi
```

3. Execute a atualização do banco de dados:
```bash
 dotnet ef database update
```

4. Inicie a API:
```bash
 dotnet run
```

### Frontend (Angular)

1. Acesse a pasta do projeto Angular:
```bash
 cd ../AppAngular
```

2. Instale as dependências:
```bash
 npm install
```

3. Inicie a aplicação Angular:
```bash
ng serve
```

4. Acesse a aplicação no navegador:
```bash
http://localhost:4200/Produtos
```

## Possíveis erros

### Erro ao executar migrations
Certifique-se de que o EF Core está instalado globalmente ou no projeto:
```bash
dotnet tool install --global dotnet-ef
```

### Erro ao executar  ng server i4.FocusTrapModule ou semelhante
No arquivo tsconfig.json deve estar  "moduleResolution": "node",
