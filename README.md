# Cast Api Cursos
<p>Esta é uma api construida para o processo seletivo da Cast Group. O objetico é criar um CRUD com .NET Core 5 e um banco de dados de livre escolha. Abaixo estão descritos alguns padrões de projeto adotados para o desenvolvimento da api.</p>

## Estrutura
<p>A estruturação do projeto objetivou a divisão das regras de negócio em services, assim tornando o código um puco mais limpo, reutilizável e facilitando a sua manutenção. Para isso o projeto se apoiou nas interfaces para realizar o contrato entre funções e classes.</p>

![Estrutura do projeto](https://github.com/DevairRestani/CastApi/blob/master/assets/md/EstruturaProjeto.png?raw=true)

<br/>

## Database
<p>O projeto está configurado para funcionar com o  [MySql](https://www.mysql.com/ "Link Mysql"). Mas para este projeto foi usado um container no docker para a hospedagem local do banco.</p>

<p>Toda a base de dados é gerada através de migrations que criam e populam as tabelas do banco ao rodar o comando: </p>

```powershell
update-database
```
![Migrations](https://github.com/DevairRestani/CastApi/blob/master/assets/md/Migrations.png?raw=true)

<br/>

## Endpoint
<p>Com a base de dados iniciada os endpoints podem ser requisitados para a ultilização da api. Quando uma requisição chega a um endpoint ela é direcionada para a camada de SeVices pelo Controller.</p>

<p>A camada Controller também fica responsavel por devolver ao cliente requisitande o resultado da operção sendo ela bem sucessida ou não.</p>

![Função do Controller de cadastro de curso](https://github.com/DevairRestani/CastApi/blob/master/assets/md/ControllerFunction.png?raw=true)

<br/>

## Service
<p>Dentro desta camada estão as regras de negócio e a conexão com o banco de dados. Os Dados vem do controller sem nenhuma validação ou tratamento. Fica então esta camada a responsevel por aplicar os tratamentos de erros e regras de negócio, se tudo estiver correto, os dados são salvos no bando ultilizado o ORM Entity Framework. Se houver algum erro a operação é interrompida e uma mensagem retorna para o controller para que o usuárioo possa corrigir os problema indicados.</p>

![Função para validação de datas](https://github.com/DevairRestani/CastApi/blob/master/assets/md/ServiceValidarDatas.png?raw=true "Função para evitar conflito entre datas")

<br/>

## Interface
<p>As interfaces desemenharam o importante papel de realizar o contrato entre as camadas e padronizar o fluxo de dados da aplicação.</p>

![Interface Service Cursos](https://github.com/DevairRestani/CastApi/blob/master/assets/md/InterfaceServiceCurso.png?raw=true)

## Fluxo de dados

<p>Com a classe CursoResponse foi possivel realizar a transferencia do objeto curso ou erro entre a camada service e controller usando o mesmo tipo de dados. Quando o construtor recebia um parametro do tipo Curso eram setadas algumas variaveis que indicavam o sucesso da operação e carregavam o objeto para o controller.
Se uma string era inseria então era assumido que ocorreu um erro e uma mensagem deve ser carregada para o controller enviar até o cliente.</p>

![Classe response](https://github.com/DevairRestani/CastApi/blob/master/assets/md/ServiceCommunicationResponse.png?raw=true)

![Classe base de response](https://github.com/DevairRestani/CastApi/blob/master/assets/md/ServiceComunicationBaseResponse.png?raw=true)
