# StaffFlow

StaffFlow é um sistema desenvolvido como parte da disciplina de **Desenvolvimento de Software para Internet** da UNIP. O objetivo principal do projeto é gerenciar *managers* e *employees* de forma eficiente e organizada.

## Tecnologias Utilizadas

- **Linguagem**: C#  
- **Framework**: .NET  
- **Banco de Dados**: SQL Server  
- **Containerização**: Docker e Docker Compose  

## Funcionalidades

- **Gestão de Managers**: Criação, atualização e exclusão de registros de gestores.
- **Gestão de Employees**: Cadastro, alteração e remoção de funcionários.
- **Interface Simples**: Uma interface intuitiva para facilitar a gestão.

## Pré-requisitos

Antes de iniciar, certifique-se de ter as seguintes ferramentas instaladas:

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)
- [SDK do .NET](https://dotnet.microsoft.com/)

Além disso, recomendamos o uso de um editor como o [Visual Studio Code](https://code.visualstudio.com/) ou [Visual Studio](https://visualstudio.microsoft.com/).

## Scripts do banco
   ```sql
CREATE DATABASE StaffFlow;
GO

USE StaffFlowDB;
GO

CREATE TABLE Manager (
    Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(),
    Name NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Department NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), 
    UpdatedAt DATETIME NULL 
);


CREATE TABLE Employee (
    Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(), 
    Name NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE, 
    Department NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), 
    UpdatedAt DATETIME NULL, 
);

CREATE INDEX IDX_Manager_Department ON Manager(Department);
CREATE INDEX IDX_Employee_Department ON Employee(Department);
   ```

## Como Rodar a Aplicação

1. **Clone o Repositório**  
   ```bash
   git clone https://github.com/gustavohenrico/staffflow.git
   cd staffflow
    ```
2. **Suba os Contêineres com Docker Compose** 
   ```bash
   docker-compose up -d
    ```
3. **Execute as Migrações** 
   ```bash
   dotnet ef database update
    ```
4. **Inicie a Aplicação** 
   ```bash
   dotnet run
    ```

## Como Contribuir
1. Faça um fork do projeto.
2. Crie uma nova branch: `git checkout -b feature/nova-funcionalidade`.
3. Faça suas alterações e realize um commit: `git commit -m 'Adiciona nova funcionalidade'`.
4. Envie suas alterações para o repositório remoto: `git push origin feature/nova-funcionalidade`.
5. Abra um Pull Request.

## Arquitetura do Banco de Dados

O banco de dados do StaffFlow possui as seguintes tabelas:

### Employee
| Campo       | Tipo            | Restrição   |
|-------------|-----------------|-------------|
| Id          | UNIQUEIDENTIFIER | PRIMARY KEY |
| Name        | NVARCHAR(255)    | NOT NULL    |
| Email       | NVARCHAR(255)    | UNIQUE      |
| Department  | NVARCHAR(255)    | NOT NULL    |
| Manager     | Manager?	     | NULLABLE    |
| ManagerId	  | UNIQUEIDENTIFIER?| NULLABLE    |

### Manager
| Campo       | Tipo            | Restrição   |
|-------------|-----------------|-------------|
| Id          | UNIQUEIDENTIFIER | PRIMARY KEY |
| Name        | NVARCHAR(255)   | NOT NULL    |
| Email       | NVARCHAR(255)   | UNIQUE      |
| Department  | NVARCHAR(255)   | NOT NULL    |


## Estrutura do Projeto
```bash
    StaffFlow/
    ├── bin/                     # Arquivos binários gerados pelo build
    ├── Contexts/                # Classes de contexto para conexão com o banco de dados
    ├── Controllers/             # Controladores da aplicação
    ├── Migrations/              # Arquivos de migração do banco de dados
    ├── Models/                  # Modelos do banco de dados
    ├── obj/                     # Arquivos temporários e de build
    ├── Properties/              # Configurações do projeto
    ├── Views/                   # Arquivos de visualização (HTML/Razor)
    ├── wwwroot/                 # Arquivos estáticos (CSS, JS, imagens)
    ├── appsettings.json         # Configurações da aplicação
    ├── docker-compose.yml       # Configuração do Docker Compose
    ├── Program.cs               # Arquivo principal do programa
    ├── StaffFlow.csproj         # Arquivo de configuração do projeto .NET
    ├── StaffFlow.sln            # Solução principal do projeto
    └── README.md                # Documentação do projeto
```