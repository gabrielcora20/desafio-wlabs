# Desafio Técnico (Wlabs)
## **Descrição**

Conforme proposto pela equipe da Wlabs durante o processo seletivo, desenvolvi este projeto a partir das especificações fornecidas. Seu objetivo é receber um CEP e buscá-lo em três endpoints de terceiros ([Via Cep](https://viacep.com.br/), [Api Cep](https://apicep.com/api-de-consulta/), [Api Awesome](https://docs.awesomeapi.com.br/api-cep)), alternando entre eles, caso algum erro ocorra. 

<br/>

### Serviços

A aplicação conta com os seguintes serviços:

* [Serviço de Autenticação](http://localhost:8090/login) - Onde o token JWT é disponibilizado para o usuário que estiver autorizado, permitindo-o acessar o endpoint de consulta de CEP.
* [Serviço de Consulta de CEP](http://localhost:8080/localizacao/01006000) - Responsável por consultar nos três serviços disponibilizados o endereço do CEP fornecido.
* [Serviço de Cadastro/Consulta de Usuários](http://localhost:8100/usuario) - Caso o usuário deseje cadastrar um novo registro no banco de dados, habilitando uma nova conta para autenticação, ele deve apenas enviar uma requisição POST a esse serviço.

<br/>

### Tecnologias Utilizadas

* Código fonte escrito em [.Net 7](https://dotnet.microsoft.com/pt-br/download/dotnet/7.0).
* Banco de dados [MongoDB](https://www.mongodb.com/).
* Autenticação JWT centralizada para todos os serviços.
* Tratativa de Log utilizando [Serilog](https://serilog.net/) e [ElasticSearch](https://www.elastic.co/pt/what-is/elasticsearch).
* Desenvolvimento da solução em microserviços, diminuindo bastante a chance de indisponibilidade da consulta por CEP.
* Arquitetura em Camadas (Services, Application, Domain, Data), utilizando o padrão CQRS.
* Orquestração dos microserviços implementada com load balancer em [NgInx](https://docs.nginx.com/nginx/admin-guide/load-balancer/http-load-balancer/) gerenciando qual dos três endpoints deverá ser chamado. Caso o escolhido dê erro, outro é automaticamente acionado, de forma imperceptível ao usuário.
* Cacheamento dos resultados recebidos pelos endpoints via [Redis](https://redis.io/docs/about/). Portanto, caso o usuário refaça a pesquisa para o mesmo CEP, não será preciso entrar em contato com nenhum dos endpoint de terceiros, pois o valor encontra-se armazenado em cache.
* Contêineres gerenciandos via [Docker](https://docs.docker.com/) e [Docker Compose](https://docs.docker.com/compose/).

<br/>

## **Instalação**

<br/>

### Pré-requisitos

* Ter o [Docker](https://docs.docker.com/get-docker/) e [Docker Compose](https://docs.docker.com/compose/install/) instalados.

<br/>

### Instruções de Execução

* Baixe o projeto
    ```sh
    git clone git@github.com:gabrielcora20/desafio-wlabs.git
    ```
* Entre na pasta do projeto
    ```sh
    cd desafio-wlabs
    ```
* Suba a aplicação no [Docker](https://docs.docker.com/)
    ```sh
    docker-compose up -d --build
    ```

## **Instuções de Utilização**

<br/>

### Requisitando Endpoints via [Postman](https://www.postman.com/downloads/)

Para a utilização dos endpoints, uma collection do [Postman](https://www.postman.com/downloads/) está disponível no arquivo JSON, contido na pasta "postman", na raiz do projeto. Para importá-lo, basta seguir o seguinte [tutorial](https://learning.postman.com/docs/getting-started/importing-and-exporting-data/#importing-data-into-postman).

<br/>

### Visualizando os logs da aplicação no [Kibana](https://www.elastic.co/pt/what-is/kibana)

Os logs da aplicação são gravados no [ElasticSearch](https://www.elastic.co/pt/what-is/elasticsearch) pelo [Serilog](https://serilog.net/), e por sua vez, podemos visualizar os dados pelo [Kibana](https://www.elastic.co/pt/what-is/kibana), acessando o seguinte [endereço](http://localhost:5601/). Mas, para vermos o conteúdo do índice, é preciso cria uma index pattern com o nome de `indexlogs`. 
* Primeiro, abra o menu principal.
* Na seção `Analytics`, clique em `Discover`.
* Aparecerá uma janela com uma mensagem dizendo `You have data in Elasticsearch. Now, create an index pattern.`, clique em `Create index pattern`.
* No campo `Name`, escreva `indexlogs`.
* E no campo `Timestamp field`, selecione `@timestamp`.
* Por fim, clique no botão `Create index pattern` na parte inferior da janela.
* Agora, volte à tela inicial.
* Abra o menu principal.
* Na seção `Analytics`, clique novamente em `Discover`.
* Agora todos os logs serão mostrados nessa tela.

<br/>

## **Observações**
Um usuário padrão já vêm cadastrado no sistema com as sequintes informações de login:

```json
{
    "Email":"wlabs@gmail.com",
    "Senha":"1234"
}
```