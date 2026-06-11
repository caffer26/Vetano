# CadastroVetano

API REST para gerenciamento de clínicas veterinárias, permitindo o cadastro de donos, pets e agendamento de consultas. Desenvolvida com foco em boas práticas de arquitetura, aplicando conceitos de DDD como entidades, value objects e use cases.

## Tecnologias

- .NET 10 / ASP.NET Core
- Entity Framework Core 9
- MySQL
- Swagger

## Como executar

1. Execute o projeto:

```bash
dotnet run --project CadastroVetano
```

A aplicação estará disponível em `http://localhost:5173` e o Swagger em `http://localhost:5173/swagger`. As migrations são aplicadas automaticamente na inicialização.
