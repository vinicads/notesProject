
# NotesApp

Este é um sistema completo para gerenciamento de anotações, composto por um backend em .NET e um frontend em Angular.  
O projeto permite criar, visualizar, editar e excluir anotações, com suporte ao upload de imagens. A autenticação é realizada via JWT.

## Tecnologias Utilizadas
### Backend
- **.NET*: Framework para construção de APIs robustas e escaláveis.
- **Entity Framework Core**: ORM para gerenciamento do banco de dados.
- **MYSQL**: Banco de dados relacional.
- **JWT (JSON Web Token)**: Para autenticação segura.

### Frontend
- **Angular**: Framework para construção de interfaces modernas e dinâmicas.
- **Bootstrap**: Para design responsivo e moderno.

## Estrutura do Projeto
O projeto segue uma organização modular para melhor manutenção e escalabilidade.  
### Backend
```
NotesApi/
├── Controllers/      # Controladores da API
├── Data/             # Repositórios e contexto do banco de dados
├── Models/           # Modelos de dados
├── Services/         # Lógica de negócios e serviços
├── DTOs/             # Objetos de transferência de dados
├── Utils/            # Helpers e middlewares
```

### Frontend
```
NotesApp/
├── src/
    ├── app/
        ├── components/    # Componentes reutilizáveis
        ├── services/      # Serviços para comunicação com a API
        ├── models/        # Interfaces e modelos de dados
        ├── pages/         # Páginas principais da aplicação
```

## Funcionalidades Planejadas
1. **Backend**:
   - Autenticação de usuários utilizando JWT.
   - CRUD de anotações, incluindo upload de imagens.
2. **Frontend**:
   - Tela de login para autenticação.
   - Tela principal com CRUD de anotações, integrando upload de imagens.
   - Design moderno e responsivo utilizando Bootstrap.

## Configuração do Ambiente
### Pré-requisitos
- **Node.js** e **Angular CLI** para o frontend.
- **.NET SDK** para o backend.
- **MYSQL** ou outro banco de dados relacional.

### Passos para Configuração
1. **Clonar o repositório**:
   ```bash
   git clone https://github.com/vinicads/notesProject.git
   cd NotesApp
   ```
2. **Configurar o Backend**:
   - Navegue até a pasta `NotesApi`:
     ```bash
     cd NotesApi
     ```
   - Instale as dependências e configure o banco de dados no arquivo de configuração `appsettings.json`.
   - Execute o backend:
     ```bash
     dotnet run
     ```
3. **Configurar o Frontend**:
   - Navegue até a pasta `NotesApp`:
     ```bash
     cd NotesApp
     ```
   - Instale as dependências:
     ```bash
     npm install
     ```
   - Execute o servidor de desenvolvimento:
     ```bash
     ng serve
     ```

## Autor

Este projeto foi desenvolvido como parte de um teste técnico para demonstrar habilidades em desenvolvimento fullstack.
