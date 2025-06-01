# BlackoutMonitorAPI

## 🚀 3ESPV - Engenharia de Software 3º Ano - Global Solution 🖥️
### 🧑‍💻 Guilherme Barreto Santos - RM97674
### 🧑‍💻 Mateus Iago Sousa Conceição - RM550270
### 🧑‍💻 Nicolas Oliveira da Silva - RM98939 

## 📄 Swagger:
	- http://localhost:7116

# 🔌 Blackout Monitor API

API RESTful desenvolvida em ASP.NET Core 8 para **monitoramento de falhas de energia elétrica** em regiões de vulnerabilidade social. O sistema permite registrar alertas, associar dispositivos a regiões, gerar relatórios e autenticar usuários via JWT.

## 💡 Sobre o Projeto
O Blackout Monitor é uma solução voltada para o monitoramento de quedas de energia elétrica em comunidades com maior vulnerabilidade social, buscando oferecer respostas rápidas e eficazes a esse tipo de incidente. A proposta visa reduzir o tempo de exposição ao risco causado por falhas de energia, que impactam diretamente a segurança, saúde e comunicação das populações afetadas.

Do ponto de vista de cibersegurança, quedas de energia representam uma ameaça crítica: podem interromper sistemas de vigilância, alarmes de segurança, redes de comunicação e servidores de dados sensíveis, deixando áreas inteiras suscetíveis a invasões físicas, vazamento de informações ou paralisação de serviços essenciais. Em cenários urbanos mais carentes, essa exposição é agravada pela ausência de infraestrutura de backup.

Para mitigar esse impacto, a solução propõe o uso de dispositivos IoT com sensores de luminosidade e corrente elétrica distribuídos por essas regiões, que coletam dados periodicamente e os transmitem a um servidor. Esse servidor, agora implementado em C# (ASP.NET Core 8), oferece uma API segura com autenticação JWT, registro de alertas, gerenciamento de dispositivos e geração de relatórios. O armazenamento dos dados é feito com o Entity Framework Core e SQLite, garantindo persistência local e leveza para ambientes mais restritos.

Esses dados podem ser acessados por aplicativos móveis ou painéis administrativos, possibilitando análises preditivas e rápidas notificações. Com isso, é possível minimizar o tempo de resposta, fortalecer a infraestrutura digital nas comunidades e reduzir os riscos cibernéticos associados a interrupções de energia.
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

