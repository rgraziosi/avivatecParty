# AvivatecParty

## Estado atual
 
 Foi Implementado o Backend, utilizando
 * .Net Core 2.2
 * DDD
 * AutoMapper
 * CQRS (Somente estrututural, para um exemplo real seria necessário um banco de dados não estruturado)
 * EF Core
 * DAPPER (exemplo comentado)
 * SWAGGER
 
 Foi Inciado o Frontend, utilizando
* Bootstrap
* Scss
* Responsividade
* Estrutuda modular
* Angular 8
* Rxjs
 
> Pontos importantes: 
* A solução tem por objetivo um a concepção de um produto, utilizando além do que foi proposto no teste, algo que possa gerar valor;
* A implementação de testes esta programada para um terceiro momento, pois preciso estudar a ferramenta do XUnit e Jasmine;
* A camada de application foi mantida por uma questão didática, podendo ser refatorado para services já que se trata de um SPA;
* A aplicação tem alguns erros forçados para exemplificação de mensagens de erro do backend - No cadastro ou edição de um participante caso não seja informada a data, ela retorna um erro pois, a data deve ser maior que a data do dia corrente;
* Algumas funcionalidades pertinentes a um ciclo de CRUD de usuário como um verificador de segurança da senha, campo de confirmação de senha, confirmador de ação em momento de exclusão poderá ser implementado em uma próxima versão pois, não queria demorar mais tempo para entregar, entretanto se for necessário para o teste eu posso fazer a implementação sem problemas.

*Qualquer explicação da estrutura, documentação, alteração ou criação de nova funcionalidade se necessário, estou a disposição. Espero que gostem e desde já agradeço.

 
<hr>

Proposta de solução :
- CRIAR UMA TELA DE CADASTRO DE USUÁRIOS (FRONTEND)
- NOME;
- E-MAIL;
- LOGIN;
- SENHA.

CRIAR AS OPERAÇÕES DE USUÁRIOS (CRUD)
- CREATE;
- UPDATE;
- READ;
- DELETE.

RECOMENDADO:
- ANGULAR;
- .NET CORE;
- DDD;
- ENTITY FRAMEWORK;
- AUTOMAPPER.

DIFERENCIAL:
- DESENVOLVER TESTES.

<hr>
 
 
