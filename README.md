# Boas vindas ao repositório do Tryitter!

   Este projeto trata-se de uma aplicação BackEnd para o **Tryitter**, uma rede social que tem como objetivo proporcionar um ambiente em que as pessoas estudantes poderão, por meio de textos e imagens, compartilhar suas experiências e também acessar posts que possam contribuir para seu aprendizado.💚

## 🛠️ Requisitos Técnicos

* Implementação com C#, SQL Server e Azure;
* O projeto terá rotas autenticadas e rotas anônimas;
* Os testes serão criados com os frameworks xUnit e FluentAssertions.

## 📋 Funcionalidades

> Implementar um C.R.U.D. para as contas de pessoas estudantes;
> 
> Implementar um C.R.U.D. para um post de uma pessoa estudante;
> 
> Alterar um post depois de publicado.
> 
> Listar todos os posts de uma pessoa estudante;

## 📦 Desenvolvimento do projeto

   No projeto haverá um Front-End que será responsável por interagir com as pessoas estudantes e mandar as muitas requisições para o Back-End, que, por sua vez, será responsável por manter as informações atualizadas em um banco de dados SQL Server usando o Framework Entity.
  
   Nessa rede social, as pessoas estudantes irão se cadastrar com nome, e-mail, módulo atual que estão estudando na Trybe, status personalizado e senha para se autenticar. Será possível também alterar essa conta a qualquer momento, desde que a pessoa usuária esteja autenticada.

   Uma pessoa estudante poderá publicar posts em seu perfil, que devem conter textos com até 300 caracteres e arquivos de imagem, além de conseguir pesquisar outras contas por nome e optar por listar todos os seus posts.
 
 ## Arquitetura da API 📝

  Foram criadas 11 rotas levando em consideração as regras de negócio e dos contratos dos serviços.
  * Endpoint (GET/Users) pega todas as contas
  * Endpoint (GET/Users/{id}) pega conta de um estudante específico
  * Endpoint (POST/Users) cria a conta de um estudante
  * Endpoint (PUT/Users/{id}) altera a conta de um estudante
  * Endpoint (DELETE/Users/{id}) deleta a conta de um estudante
  * 
  * Endpoint (GET/TryitterPosts) pega todos os posts
  * Endpoint (GET/TryitterPosts/{id}) pega um post específico
  * Endpoint (GET/TryitterPosts/User) pega posts de um estudante específico
  * Endpoint (POST/TryitterPosts) cria um post
  * Endpoint (PUT/TryitterPosts/{id}) altera um post
  * Endpoint (DELETE/TryitterPosts/{id}) deleta um post
---
