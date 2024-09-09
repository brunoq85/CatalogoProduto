# Projeto catálogo de produtos com MongoDB e C#

## Descrição
Este projeto é uma API desenvolvida em C# utilizando ASP.NET Core e MongoDB. A API permite buscar itens em um banco de dados MongoDB.

## Tecnologias Utilizadas
- **C#**
- **ASP.NET Core**
- **MongoDB**
- **MongoDB.Driver**
- **SQL Server**

## Mapeamento das Rotas
- **GET /api/produtos/todos**: Busca todos os itens no banco de dados MongoDB.
- **GET /api/produtos/buscarporid{id}**: Busca um item pelo id no banco de dados MongoDB.
- **POST /api/produtos/inserir**: Insere um produto no banco de dados SQL Server e no MongoDB.
- **PUT /api/produtos/alterar**: Altera um produto no banco de dados SQL Server e no MongoDB.
- **DELETE /api/produtos/excluir**: Exclui um produto no banco de dados SQL Server e no MongoDB.

## Importância de Utilizar Bancos de Dados Normalizados e Não Normalizados

### SQL Server (Banco de Dados Normalizado)
- **Vantagens**:
  - **Integridade dos Dados**: A normalização reduz a redundância e garante a integridade dos dados.
  - **Consultas Complexas**: Suporta consultas complexas e relacionamentos entre tabelas.
  - **Transações**: Suporte robusto a transações, garantindo consistência dos dados.

- **Desvantagens**:
  - **Desempenho**: Pode ser mais lento para operações de leitura e escrita em grandes volumes de dados.
  - **Escalabilidade**: Escalar horizontalmente pode ser mais desafiador.

### MongoDB (Banco de Dados Não Normalizado)
- **Vantagens**:
  - **Flexibilidade**: Estrutura de dados flexível, permitindo armazenar documentos JSON com diferentes esquemas.
  - **Desempenho**: Alta performance para operações de leitura e escrita.
  - **Escalabilidade**: Facilmente escalável horizontalmente.

- **Desvantagens**:
  - **Consistência**: Pode não garantir a consistência dos dados em todas as operações.
  - **Consultas Complexas**: Menos eficiente para consultas complexas e relacionamentos entre dados.

## Como Executar o Projeto
1. Clone o repositório.
2. Instale as dependências utilizando o NuGet Package Manager.
3. Configure a string de conexão com o MongoDB no arquivo `appsettings.json`.
4. Execute o projeto utilizando o Visual Studio ou o comando `dotnet run`.



