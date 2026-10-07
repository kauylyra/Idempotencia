WebApiIdempotencia

API desenvolvida em .NET 8 com o objetivo de estudar e demonstrar o conceito de idempotência em APIs REST, utilizando cache para controlar requisições repetidas.

O projeto foi criado como laboratório de estudos para entender, na prática, como evitar que uma mesma operação seja processada mais de uma vez, principalmente em cenários como pagamentos, criação de pedidos e outras operações que não devem ser executadas novamente em caso de repetição da requisição.

Tecnologias utilizadas

C#

.NET 8

ASP.NET Core Web API

IdempotentAPI

IDistributedCache

Distributed Memory Cache

Swagger / OpenAPI

Postman

O que estou estudando neste projeto

Conceito de idempotência em APIs REST

Uso de IdempotencyKey

Armazenamento temporário de respostas em cache

Prevenção de processamento duplicado

Injeção de dependência no ASP.NET Core

Configuração de bibliotecas de terceiros

Testes de requisições idempotentes utilizando Swagger e Postman

Como funciona

A API possui um endpoint POST protegido por idempotência.

Na primeira requisição, a operação é executada normalmente e a resposta é armazenada no cache.

Quando a mesma requisição é enviada novamente utilizando a mesma IdempotencyKey, a API pode reutilizar a resposta armazenada em vez de executar a operação novamente.

Fluxo simplificado

Cliente → POST + IdempotencyKey → API → Verifica a chave

Chave nova → Executa a operação → Salva a resposta no cache

Chave existente → Retorna a resposta armazenada

Exemplo de requisição

POST /api/User

Content-Type: application/json

IdempotencyKey: 5E7E8CE0-1071-430A-953E-09928AE9B32E

Body:

{
"name": "Kauy"
}

Ao enviar novamente a requisição utilizando a mesma IdempotencyKey, a ideia é evitar que a operação seja processada novamente.

Executando o projeto

Pré-requisitos

.NET 8 SDK

Visual Studio 2022 ou outro editor de sua preferência

Executar

Clone o repositório:

git clone https://github.com/kauylyra/WebApiIdempotencia.git

Entre na pasta do projeto:

cd WebApiIdempotencia

Restaure as dependências:

dotnet restore

Execute a aplicação:

dotnet run

Depois, acesse o Swagger pela URL informada pela aplicação.

Objetivo do projeto

Este projeto faz parte dos meus estudos de desenvolvimento backend com .NET e tem como foco aprofundar conhecimentos em:

Idempotência

APIs REST

Cache

Tratamento de requisições repetidas

Desenvolvimento de APIs com ASP.NET Core

A ideia é evoluir o projeto conforme avanço nos estudos, explorando posteriormente cenários como Redis, múltiplas instâncias da API, concorrência e outros mecanismos utilizados em aplicações distribuídas.

Próximos estudos

Testes automatizados para cenários idempotentes

Redis como armazenamento distribuído

Cenários com múltiplas instâncias da API

Concorrência e processamento simultâneo

Persistência de chaves de idempotência

Aplicação do conceito em cenários de pagamento

Projeto desenvolvido para fins de estudo e experimentação com .NET.
