# 🏋️ Trainly API - Guia Completo

> **API REST para gerenciamento de treinos e academias**  
> Projeto educacional usando .NET 10, ASP.NET Core Web API e Clean Architecture

---

## 📚 Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Arquitetura e Padrões](#arquitetura-e-padrões)
- [Estrutura de Projetos](#estrutura-de-projetos)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Como Começar](#como-começar)
- [Conceitos Importantes](#conceitos-importantes)
- [Fluxo de uma Requisição](#fluxo-de-uma-requisição)
- [Exemplos Práticos](#exemplos-práticos)

---

## 🎯 Sobre o Projeto

O **Trainly** é uma API REST construída para gerenciar treinos, alunos e academias. O projeto foi desenvolvido com foco **educacional**, usando boas práticas de desenvolvimento e padrões reconhecidos pela comunidade .NET.

### Objetivos de Aprendizado

- ✅ Entender **Clean Architecture** na prática
- ✅ Aplicar o padrão **CQRS** (Command Query Responsibility Segregation)
- ✅ Trabalhar com **Entity Framework Core** e SQL Server
- ✅ Implementar **Dependency Injection** (Injeção de Dependências)
- ✅ Criar APIs RESTful seguindo boas práticas
- ✅ Entender a separação de responsabilidades em camadas

---

## 🏗️ Arquitetura e Padrões

### Clean Architecture (Arquitetura Limpa)

A aplicação está dividida em **4 camadas**, cada uma com uma responsabilidade específica:

```
┌─────────────────────────────────────────┐
│          Trainly.API (Apresentação)     │  ← Controllers, Endpoints
├─────────────────────────────────────────┤
│       Trainly.Application (Aplicação)   │  ← CQRS (Commands/Queries)
├─────────────────────────────────────────┤
│         Trainly.Domain (Domínio)        │  ← Entidades, Regras de Negócio
├─────────────────────────────────────────┤
│    Trainly.Infrastructure (Infraestr.)  │  ← Banco de Dados, Repositórios
└─────────────────────────────────────────┘
```

**Princípio fundamental:** As camadas internas **NÃO** conhecem as camadas externas.

### Padrão CQRS (Simplificado)

Separamos as operações em dois tipos:

- **Commands (Comandos):** Alteram o estado (CREATE, UPDATE, DELETE)
- **Queries (Consultas):** Apenas leem dados (GET)

**Por que usar?**
- Código mais organizado e fácil de testar
- Separação clara entre leitura e escrita
- Facilita a manutenção e evolução do código

---

## 📁 Estrutura de Projetos

### 1️⃣ **Trainly.API** (Camada de Apresentação)

**Responsabilidade:** Receber requisições HTTP e retornar respostas.

```
Trainly.API/
├── Controllers/          # Controllers da API (recebem as requisições)
│   └── HealthController.cs
├── Program.cs           # Configuração da aplicação (DI, Middleware, etc)
├── appsettings.json     # Configurações (connection strings, logs, etc)
└── Trainly.API.csproj   # Arquivo do projeto
```

**O que vai aqui:**
- ✅ Controllers (endpoints da API)
- ✅ Configuração de DI (Dependency Injection)
- ✅ Configuração de middleware (CORS, Authentication, etc)
- ❌ **NÃO** coloque regras de negócio aqui!

---

### 2️⃣ **Trainly.Application** (Camada de Aplicação)

**Responsabilidade:** Orquestrar as operações e aplicar regras de negócio.

```
Trainly.Application/
├── Commands/            # Operações que ALTERAM dados
│   ├── CreateWorkout/
│   │   ├── CreateWorkoutCommand.cs
│   │   └── CreateWorkoutHandler.cs
│   └── UpdateWorkout/
│       ├── UpdateWorkoutCommand.cs
│       └── UpdateWorkoutHandler.cs
├── Queries/             # Operações que LEEM dados
│   ├── GetWorkout/
│   │   ├── GetWorkoutQuery.cs
│   │   └── GetWorkoutHandler.cs
│   └── ListWorkouts/
│       ├── ListWorkoutsQuery.cs
│       └── ListWorkoutsHandler.cs
└── Trainly.Application.csproj
```

**O que vai aqui:**
- ✅ Commands (criar, atualizar, deletar)
- ✅ Queries (buscar, listar)
- ✅ Handlers (processam os Commands/Queries)
- ✅ DTOs (Data Transfer Objects - objetos de transferência)
- ✅ Validações de negócio

**Exemplo de Command:**
```csharp
// CreateWorkoutCommand.cs - Define O QUE queremos fazer
public class CreateWorkoutCommand
{
    public string Name { get; set; }
    public string Description { get; set; }
}

// CreateWorkoutHandler.cs - Define COMO fazer
public class CreateWorkoutHandler
{
    // Aqui fica a lógica de criação
}
```

---

### 3️⃣ **Trainly.Domain** (Camada de Domínio)

**Responsabilidade:** Representar as entidades e regras de negócio do domínio.

```
Trainly.Domain/
├── Entities/            # Entidades do domínio (modelos)
│   ├── Workout.cs
│   ├── Exercise.cs
│   ├── Student.cs
│   └── Gym.cs
├── Enums/              # Enumeradores
│   └── WorkoutDifficulty.cs
└── Trainly.Domain.csproj
```

**O que vai aqui:**
- ✅ Entidades (classes que representam tabelas do banco)
- ✅ Value Objects (objetos de valor)
- ✅ Enums
- ✅ Interfaces de repositórios (contratos)
- ❌ **NÃO** coloque Entity Framework ou SQL aqui!

**Exemplo de Entidade:**
```csharp
public class Workout
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    
    // Relacionamentos
    public List<Exercise> Exercises { get; set; }
}
```

---

### 4️⃣ **Trainly.Infrastructure** (Camada de Infraestrutura)

**Responsabilidade:** Implementar acesso a dados e serviços externos.

```
Trainly.Infrastructure/
├── Data/
│   ├── TrainlyDbContext.cs        # Contexto do Entity Framework
│   ├── Configurations/            # Configurações das entidades
│   │   ├── WorkoutConfiguration.cs
│   │   └── ExerciseConfiguration.cs
│   └── Migrations/                # Migrations do banco (criadas automaticamente)
├── Repositories/                  # Implementação dos repositórios
│   ├── WorkoutRepository.cs
│   └── ExerciseRepository.cs
└── Trainly.Infrastructure.csproj
```

**O que vai aqui:**
- ✅ DbContext (Entity Framework)
- ✅ Repositórios (acesso ao banco de dados)
- ✅ Configurações de entidades (Fluent API)
- ✅ Migrations
- ✅ Integrações com serviços externos

---

## 🛠️ Tecnologias Utilizadas

| Tecnologia | Versão | Finalidade |
|------------|--------|------------|
| **.NET** | 10.0 | Framework principal |
| **ASP.NET Core** | 10.0 | Framework web para APIs |
| **Entity Framework Core** | 10.0 | ORM para acesso ao banco |
| **SQL Server** | 2019+ | Banco de dados relacional |
| **Swagger** | 7.2.0 | Documentação da API |

---

## 🚀 Como Começar

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server) (ou SQL Server Express)
- [Visual Studio 2024](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)
- [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms) - opcional

### Passo a Passo

#### 1. Clone ou baixe o projeto

```bash
git clone <seu-repositorio>
cd Trainly
```

#### 2. Restaure os pacotes NuGet

```bash
dotnet restore
```

#### 3. Configure a Connection String

Edite o arquivo `Trainly.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TrainlyDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**Ajuste conforme seu ambiente:**
- `localhost` → endereço do seu SQL Server
- `TrainlyDb` → nome do banco de dados
- Se usar usuário/senha: `Server=localhost;Database=TrainlyDb;User Id=seu_usuario;Password=sua_senha;`

#### 4. Execute a aplicação

```bash
cd Trainly.API
dotnet run
```

#### 5. Acesse a aplicação

- **Swagger UI:** https://localhost:5001
- **Health Check:** https://localhost:5001/api/health
- **Health Check Detalhado:** https://localhost:5001/api/health/detailed

---

## 💡 Conceitos Importantes

### 1. Dependency Injection (Injeção de Dependências)

**O que é?**  
Um padrão onde você "injeta" as dependências de uma classe ao invés de criar dentro dela.

**Exemplo SEM DI (ruim):**
```csharp
public class WorkoutController
{
    private WorkoutRepository _repository;
    
    public WorkoutController()
    {
        _repository = new WorkoutRepository(); // ❌ Acoplamento forte
    }
}
```

**Exemplo COM DI (bom):**
```csharp
public class WorkoutController
{
    private readonly IWorkoutRepository _repository;
    
    // A dependência é injetada pelo construtor
    public WorkoutController(IWorkoutRepository repository)
    {
        _repository = repository; // ✅ Desacoplado e testável
    }
}
```

**Por que é importante?**
- ✅ Facilita testes (você pode usar mocks)
- ✅ Reduz acoplamento
- ✅ Facilita manutenção

### 2. Entity Framework Core

**O que é?**  
Um ORM (Object-Relational Mapper) que permite trabalhar com banco de dados usando objetos C#.

**Ao invés de escrever SQL:**
```sql
SELECT * FROM Workouts WHERE Id = 1
```

**Você escreve C#:**
```csharp
var workout = await _context.Workouts.FindAsync(1);
```

### 3. Migrations (Migrações)

**O que são?**  
Arquivos que representam mudanças no banco de dados.

**Comandos importantes:**
```bash
# Criar uma migration
dotnet ef migrations add NomeDaMigration --project Trainly.Infrastructure --startup-project Trainly.API

# Aplicar migrations no banco
dotnet ef database update --project Trainly.Infrastructure --startup-project Trainly.API

# Remover última migration
dotnet ef migrations remove --project Trainly.Infrastructure --startup-project Trainly.API
```

### 4. DTOs (Data Transfer Objects)

**O que são?**  
Objetos usados para transferir dados entre camadas.

**Por que usar?**
- ✅ Controlar quais dados são expostos pela API
- ✅ Separar modelo do banco (entidade) do modelo da API (DTO)
- ✅ Facilitar validações

**Exemplo:**
```csharp
// Entidade (Domain)
public class Workout
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

// DTO (Application)
public class WorkoutDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    // Note: não expõe CreatedAt e UpdatedAt
}
```

---

## 🔄 Fluxo de uma Requisição

Vamos entender o caminho que uma requisição percorre:

```
┌─────────────┐
│   Cliente   │ (Postman, Frontend, etc)
└──────┬──────┘
       │ HTTP Request
       ▼
┌─────────────────────────────────────┐
│  1. Controller (API)                │
│  Recebe a requisição HTTP           │
│  Valida dados básicos               │
└──────┬──────────────────────────────┘
       │
       ▼
┌─────────────────────────────────────┐
│  2. Handler (Application)           │
│  Processa o Command/Query           │
│  Aplica regras de negócio           │
└──────┬──────────────────────────────┘
       │
       ▼
┌─────────────────────────────────────┐
│  3. Repository (Infrastructure)     │
│  Acessa o banco de dados            │
│  Retorna entidades                  │
└──────┬──────────────────────────────┘
       │
       ▼
┌─────────────────────────────────────┐
│  4. DbContext (Infrastructure)      │
│  Entity Framework                   │
│  SQL Server                         │
└──────┬──────────────────────────────┘
       │
       ▼ Resposta volta pelo mesmo caminho
┌─────────────┐
│   Cliente   │ (recebe JSON)
└─────────────┘
```

---

## 📝 Exemplos Práticos

### Exemplo 1: Criar um Novo Treino

**1. Command (Application/Commands/CreateWorkout/)**
```csharp
public class CreateWorkoutCommand
{
    public string Name { get; set; }
    public string Description { get; set; }
}
```

**2. Handler (Application/Commands/CreateWorkout/)**
```csharp
public class CreateWorkoutHandler
{
    private readonly TrainlyDbContext _context;

    public CreateWorkoutHandler(TrainlyDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateWorkoutCommand command)
    {
        var workout = new Workout
        {
            Name = command.Name,
            Description = command.Description,
            CreatedAt = DateTime.UtcNow
        };

        _context.Workouts.Add(workout);
        await _context.SaveChangesAsync();

        return workout.Id;
    }
}
```

**3. Controller (API/Controllers/)**
```csharp
[ApiController]
[Route("api/[controller]")]
public class WorkoutsController : ControllerBase
{
    private readonly CreateWorkoutHandler _handler;

    public WorkoutsController(CreateWorkoutHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateWorkoutCommand command)
    {
        var id = await _handler.Handle(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}
```

---

## 🎓 Dicas de Estudo

### Para Iniciantes

1. **Comece pelo Domain:** Entenda as entidades e o modelo de dados
2. **Depois vá para Infrastructure:** Veja como os dados são persistidos
3. **Application em seguida:** Entenda a lógica de negócio
4. **Por último, a API:** Veja como tudo se conecta

### Recursos Recomendados

- 📚 [Documentação oficial do .NET](https://docs.microsoft.com/dotnet)
- 📚 [Entity Framework Core](https://docs.microsoft.com/ef/core)
- 📚 [Clean Architecture - Uncle Bob](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- 🎥 [Canal do Elemar Jr (YouTube)](https://www.youtube.com/@EximiaCo)
- 🎥 [balta.io - Cursos .NET](https://balta.io)

---

## ❓ Perguntas Frequentes

### "Por que 4 projetos ao invés de 1?"

Separação de responsabilidades! Cada projeto tem um propósito específico e pode evoluir independentemente.

### "Quando devo criar um Command vs uma Query?"

- **Command:** Quando você vai ALTERAR dados (POST, PUT, DELETE)
- **Query:** Quando você vai apenas LER dados (GET)

### "Preciso sempre usar DTOs?"

Para projetos pequenos, pode usar as entidades diretamente. Mas é uma boa prática usar DTOs para:
- Controlar quais dados são expostos
- Facilitar versionamento da API
- Separar modelo interno do externo

---

