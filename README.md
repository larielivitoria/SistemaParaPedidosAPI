# SistemaParaPedidosAPI

### Desenvolvi esse projeto para consolidar meus conhecimentos em arquitetura limpa.

Explorei estrutura em camadas API - Domain - Application - Infrastructure

Explorei o Repository Pattern, fazendo com que apenas acesse os dados sem manipulação.

Explorei a Injeção de Dependência - Injetando o que a classe precisava via construtor, ao invés de deixa-la responsável por instânciar o Objeto.

Me esforcei para aplicar Boas Práticas e garantir baixo acoplamento, separação de responsabilidades, código limpo e organizado.

Usei DTOs para proteger minhas Entidades, e não expor dados internos diretamente.

Entendi o fluxo de dados de uma API - API chama a Controller, a Controller chama o Service, o Service chama o Repository, o Repository chama o DbContext, e o DbContext acessa o Banco de Dados.
