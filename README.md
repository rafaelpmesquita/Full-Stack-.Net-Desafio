# Full Stack .Net Desafio

## Tarefa

O desafio consiste em criar uma interface de usuário para o gerenciamento de leads de uma empresa. O aplicativo deve ser desenvolvido como uma Single Page Application (SPA), utilizando uma estrutura JS moderna à sua escolha, suportada por uma API .Net Core e um banco de dados SQL Server.

### Guia Invited

A guia Invited exibe todos os leads no status "Invited". Cada lead é representado como um cartão com as seguintes informações:
- Nome do contato
- Data de criação
- Subúrbio
- Categoria
- ID
- Descrição
- Preço

Além disso, há dois botões:
- **Accept**: Atualiza o status do lead para "Aceito" no banco de dados. Se o preço for superior a US $ 500, é aplicado um desconto de 10%. Após a aceitação, o sistema envia uma notificação por e-mail para vendas@test.com.
- **Decline**: Atualiza o status do lead para "Recusado" no banco de dados.

### Guia Aceito

A guia Aceito exibe todos os leads no status "Aceito", com dados adicionais nos cartões:
- Nome completo do contato
- Número de telefone do contato
- E-mail do contato

## Notas

- Utilize ícones font-awesome ou SVG na interface do usuário.
- Escolha entre React, Angular ou outra estrutura JS moderna.
- Pré-requisitos incluem .Net Core 6, SPA, banco de dados SQL Server e ORM (EF).
- "Bom de Ter (Avançado)": Implemente CQRS com MediatR e siga princípios DDD.
- "Bom de Ter (Super Avançado)": Considere Event Sourcing.

## Critério de Avaliação

A avaliação considera habilidades de codificação limpa, design, resolução de problemas e uso de tecnologias modernas.

## Entregáveis

- Repositório GIT com a solução.
- Instruções claras sobre como executar o aplicativo.

## Tabela Leads

A tabela `Leads` representa informações sobre leads, incluindo detalhes sobre o contato, data de criação, localização, categoria e status.

| Nome da Coluna       | Tipo de Dado      | Restrições                   | Descrição                                              |
|----------------------|-------------------|-----------------------------|--------------------------------------------------------|
| Id                   | INT               | PRIMARY KEY, IDENTITY(1,1)    | Identificador único para cada lead                      |
| ContactFirstName     | NVARCHAR(100)     | NOT NULL                    | Primeiro nome da pessoa de contato                      |
| DateCreated          | DATETIME          | NOT NULL                    | Data e hora em que o lead foi criado                   |
| Suburb               | NVARCHAR(100)     |                             | Bairro ou local relacionado ao lead                    |
| Category             | NVARCHAR(50)      |                             | Categoria ou tipo do lead                               |
| Description          | NVARCHAR(MAX)     |                             | Descrição detalhada do lead                            |
| Price                | DECIMAL(18,2)     | NOT NULL                    | Preço associado ao lead                                |
| ContactFullName      | NVARCHAR(100)     |                             | Nome completo da pessoa de contato                     |
| ContactPhoneNumber   | NVARCHAR(20)      |                             | Número de telefone da pessoa de contato                |
| ContactEmail         | NVARCHAR(100)     |                             | Endereço de e-mail da pessoa de contato                |
| StatusLeadId         | INT               | FOREIGN KEY                 | Referência à tabela `StatusLead`, indicando o status do lead (Aceito, Recusado, Pendente) |

## Tabela StatusLead

A tabela `StatusLead` representa os possíveis status que um lead pode ter.

| Nome da Coluna | Tipo de Dado    | Restrições                   | Descrição                        |
|----------------|-----------------|-----------------------------|----------------------------------|
| Id             | INT             | PRIMARY KEY, IDENTITY(1,1)  | Identificador único para cada status |
| Descricao      | NVARCHAR(50)    | NOT NULL                    | Descrição do status do lead       |


