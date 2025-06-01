- Guilherme Barreto Santos RM


# 🔌 Blackout Monitor API

API RESTful desenvolvida em ASP.NET Core 8 para **monitoramento de falhas de energia elétrica** em regiões de vulnerabilidade social. O sistema permite registrar alertas, associar dispositivos a regiões, gerar relatórios e autenticar usuários via JWT.

---

## ✅ Funcionalidades principais

- 📍 Cadastro e consulta online ou cache de **regiões** por CEP (utilizando o serviço ViaCEP)
- 📡 Cadastro de **dispositivos** físicos associados a uma região
- 🚨 Registro de **alertas de falta de energia**, manuais ou por dispositivo
- 👤 **Controle de usuários** com autenticação via JWT
- 🔐 Rotas protegidas com `[Authorize]`
- 📊 **Relatório de alertas** e dispositivos por região
- 🩺 **Health check** básico e completo com verificação do banco
- 🧾 **Logs de operação** com `ILogger`
- ❌ Tratamento global de erros com `GlobalExceptionHandler`

---

## 🛠️ Tecnologias utilizadas

- [.NET 8](https://dotnet.microsoft.com)
- ASP.NET Core Web API
- Entity Framework Core + SQLite
- Autenticação JWT
- Swagger (Swashbuckle)
- RESTful API
- C#

---

## 🧬 Estrutura de pastas
BlackoutMonitorAPI/
├── Controller/
│ ├── AlertsController.cs
│ ├── AuthController.cs
│ ├── DevicesController.cs
│ ├── HealthController.cs
│ └── RegionController.cs
├── Data/
│ └── ApplicationDbContext.cs
├── Dto/
│ ├── AlertCreateDto.cs
│ ├── DeviceCreateDto.cs
│ ├── DeviceResponseDto.cs
│ └── UserLoginDto.cs, UserRegisterDto.cs
├── Exceptions/
│ ├── RegionNotFoundException.cs
│ ├── UserNotAuthenticatedException.cs
│ └── DatabaseUnavailableException.cs
│ └── AlertNotFoundException.cs
│ └── GlobalExceptionHandler.cs
├── Model/
│ ├── Alert.cs
│ ├── Region.cs
│ ├── Device.cs
│ └── User.cs
├── Service/
│ └── IRegionService.cs
│ └── IUserService.cs
│ └── RegionService.cs
│ └── UserService.cs
├── Program.cs
├── appsettings.json
├── blackout.db
└── README.md


---

## ▶️ Como executar o projeto

1. Clone o repositório:

   ```bash
   git clone https://github.com/gui2604/BlackoutMonitorAPI.git
   cd BlackoutMonitorAPI
   ```
2. Restaure os pacotes NuGet:
   ```bash
   dotnet restore
   ```
3. Crie o banco de dados e aplique as migrações:
   ```bash
   dotnet ef database update
   ```
4. Execute a aplicação:
   ```bash
   dotnet run
   ```
5. Acesse o Swagger UI:
	```bash
	https://localhost:7116/swagger
   ```

## 🔐 Autenticação JWT
### 📌 Endpoints públicos
- POST /api/auth/register – Cria novo usuário

- POST /api/auth/login – Retorna token JWT

- GET /api/healthcheck – Health check público

## 🔐 Endpoints protegidos (requer token)
- Gerenciamento de Regiões, alertas, dispositivos e relatórios

## 🧪 Teste no Swagger
- 1. Faça login em /api/auth/login
	1.1 Utilize as credenciais:
		Email: professor@fiap.com.br
		Senha: 12345678

- 2. Copie o token retornado

- 3. Clique em Authorize no canto superior direito do Swagger

- Cole o token:
- Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...