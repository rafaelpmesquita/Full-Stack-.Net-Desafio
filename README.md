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

## Submissão

Disponibilize a solução em um repositório GIT e inclua instruções detalhadas. Boa sorte!
