# FindaBeer

## Descri��o

Este � um prot�tipo de um micro servi�o que possibilita o cadastro de cervejas e sua harmoniza��o.

Este micro servi�o permite o usu�rio visualizar, procurar, cadastrar, editar e excluir cervejas. Al�m disso, este micro servi�o tamb�m conta com uma API REST.

O design da aplica��o e as tecnologias adotadas neste projeto possuem como objetivo ser simples e pr�tico.

Para executar o projeto, bastar iniciar o projeto **docker-compose**. � preciso instalar o Docker e estar com a porta 27017 livre para uso.

Ao iniciar o projeto, o sistema ir� automaticamente realizar a instala��o de uma imagem do MongoDB atrav�s do Docker e tamb�m ir� inserir uma carga de dados para testes no ambiente de desenvolvimento.

A documenta��o da API REST pode ser encontrada dentro do pr�prio projeto na url **/api/help**.

## Tecnologias

Este micro servi�o foi desenvolvido utilizando o .Net Core no back-end, AngularJS no front-end, MongoDB para persist�ncia e Docker para virtualiza��o dos cont�ineres.

Este projeto est� dividido em:
* **FindaBeer.Web**: Cont�m os endpoints da API REST e tamb�m os arquivos do front-end.
* **FindaBeer.Services**: Cont�m a l�gica de neg�cio e realiza a persist�ncia dos dados.
* **FindaBeer.Staging**: Permite adicionar uma carga de dados para testes no ambiente de desenvolvimento.

## Considera��es

O cadastro de ingredientes poderia ser melhorado para permitir adicionar novos ingredientes.

A lista de cervejas poderia ser melhorada para permitir pagina��o.

O cadastro da foto da cerveja poderia ser melhorado para ser salvo em um sistema de arquivos, ao inv�s de salvar as imagens no formato base64, para permitir a utiliza��o de cache do navegador e diminuir a carga do banco de dados.

A escolha do AngularJS 1.8 para o front-end foi motivado apenas por eu j� ter dom�nio nessa tecnologia. Em outros projetos, dificilmente eu voltaria e escolher o AngularJS por se tratar de tecnologia que j� pode ser considerada legada.

Eu n�o consegui concluir o filtro de cor. Daria para ser feito, mas por uma quest�o de tempo eu n�o consegui concluir � tempo da conclus�o do projeto.

Eu n�o consegui desenvolver os testes automatizados porque eu n�o consegui rodar eles dentro de um container docker.