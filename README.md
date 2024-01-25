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

## Leads Table

The `Leads` table represents information about leads, including details about the contact, creation date, location, category, and status.

| Column Name          | Data Type         | Constraints                   | Description                                              |
|----------------------|-------------------|-------------------------------|----------------------------------------------------------|
| Id                   | INT               | PRIMARY KEY, IDENTITY(1,1)    | Unique identifier for each lead                           |
| ContactFirstName     | NVARCHAR(100)     | NOT NULL                      | First name of the contact person                          |
| DateCreated          | DATETIME          | NOT NULL                      | Date and time when the lead was created                   |
| Suburb               | NVARCHAR(100)     |                               | Suburb or location related to the lead                    |
| Category             | NVARCHAR(50)      |                               | Category or type of the lead                              |
| Description          | NVARCHAR(MAX)     |                               | Detailed description of the lead                         |
| Price                | DECIMAL(18,2)     | NOT NULL                      | Price associated with the lead                            |
| ContactFullName      | NVARCHAR(100)     |                               | Full name of the contact person                           |
| ContactPhoneNumber   | NVARCHAR(20)      |                               | Phone number of the contact person                        |
| ContactEmail         | NVARCHAR(100)     |                               | Email address of the contact person                       |
| StatusLeadId         | INT               | FOREIGN KEY                   | References the `StatusLead` table, indicating the status of the lead (Accepted, Declined, Pending) |

## StatusLead Table

The `StatusLead` table represents the possible statuses that a lead can have.

| Column Name | Data Type    | Constraints                   | Description                           |
|-------------|--------------|-------------------------------|---------------------------------------|
| Id          | INT          | PRIMARY KEY, IDENTITY(1,1)    | Unique identifier for each status     |
| Descricao   | NVARCHAR(50) | NOT NULL                      | Description of the lead status        |

## Sample Data

Ten sample leads have been inserted into the `Leads` table to provide realistic data for testing and development purposes.

