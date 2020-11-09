# FindaBeer

## Descrição

Este é um protótipo de um micro serviço que possibilita o cadastro de cervejas e sua harmonização.

Este micro serviço permite o usuário visualizar, procurar, cadastrar, editar e excluir cervejas. Além disso, este micro serviço também conta com uma API REST.

O design da aplicação e as tecnologias adotadas neste projeto possuem como objetivo ser simples e prático.

Para executar o projeto, bastar iniciar o projeto **docker-compose**. É preciso instalar o Docker e estar com a porta 27017 livre para uso.

Ao iniciar o projeto, o sistema irá automaticamente realizar a instalação de uma imagem do MongoDB através do Docker e também irá inserir uma carga de dados para testes no ambiente de desenvolvimento.

A documentação da API REST pode ser encontrada dentro do próprio projeto na url **/api/help**.

## Tecnologias

Este micro serviço foi desenvolvido utilizando o .Net Core no back-end, AngularJS no front-end, MongoDB para persistência e Docker para virtualização dos contêineres.

Este projeto está dividido em:
* **FindaBeer.Web**: Contém os endpoints da API REST e também os arquivos do front-end.
* **FindaBeer.Services**: Contém a lógica de negócio e realiza a persistência dos dados.
* **FindaBeer.Staging**: Permite adicionar uma carga de dados para testes no ambiente de desenvolvimento.

## Considerações

O cadastro de ingredientes poderia ser melhorado para permitir adicionar novos ingredientes.

A lista de cervejas poderia ser melhorada para permitir paginação.

O cadastro da foto da cerveja poderia ser melhorado para ser salvo em um sistema de arquivos, ao invés de salvar as imagens no formato base64, para permitir a utilização de cache do navegador e diminuir a carga do banco de dados.

A escolha do AngularJS 1.8 para o front-end foi motivado apenas por eu já ter domínio nessa tecnologia. Em outros projetos, dificilmente eu voltaria e escolher o AngularJS por se tratar de tecnologia que já pode ser considerada legada.

Eu não consegui concluir o filtro de cor. Daria para ser feito, mas por uma questão de tempo eu não consegui concluir à tempo da conclusão do projeto.

Eu não consegui desenvolver os testes automatizados porque eu não consegui rodar eles dentro de um container docker.