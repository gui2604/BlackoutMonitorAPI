﻿# BlackoutMonitorAPI - C# Software Development

## 🚀 3ESPV - Engenharia de Software 3º Ano - Global Solution 🖥️
### 🧑‍💻 Guilherme Barreto Santos - RM97674
### 🧑‍💻 Mateus Iago Sousa Conceição - RM550270
### 🧑‍💻 Nicolas Oliveira da Silva - RM98939 

## 📄 Swagger:
	- http://localhost:7116/swagger

# 🖥️  Blackout Monitor API

API RESTful desenvolvida em ASP.NET Core 8 para **monitoramento de falhas de energia elétrica** em regiões de vulnerabilidade social. O sistema permite registrar alertas, associar dispositivos a regiões, gerar relatórios e autenticar usuários via JWT.

## 💡 Sobre o Projeto
O Blackout Monitor é uma solução voltada para o monitoramento de quedas de energia elétrica em comunidades com maior vulnerabilidade social, buscando oferecer respostas rápidas e eficazes a esse tipo de incidente. A proposta visa reduzir o tempo de exposição ao risco causado por falhas de energia, que impactam diretamente a segurança, saúde e comunicação das populações afetadas.

Do ponto de vista de cibersegurança, quedas de energia representam uma ameaça crítica: podem interromper sistemas de vigilância, alarmes de segurança, redes de comunicação e servidores de dados sensíveis, deixando áreas inteiras suscetíveis a invasões físicas e cibernéticas, vazamento de informações e paralisação de serviços essenciais. Em cenários urbanos mais carentes, essa exposição é ainda mais agravada pela ausência de infraestrutura física e tecnológica.

Para mitigar esse impacto, a solução do Blackout Monitor propõe o uso de dispositivos IoT com sensores de luminosidade e corrente elétrica distribuídos por essas regiões alimentados com a corrente elétrica dos postes de rua trocando para uma bateria acoplada na falta de energia, que coletam dados periodicamente e os transmitem a um servidor. Esse servidor, agora implementado em C# (ASP.NET Core 8), oferece uma API segura com autenticação JWT, registro de alertas, gerenciamento de dispositivos e geração de relatórios. O armazenamento dos dados é feito com o Entity Framework Core e SQLite, garantindo persistência local e leveza para ambientes mais restritos.

Esses dados podem ser acessados por aplicativos móveis ou painéis administrativos, possibilitando análises preditivas e rápidas notificações e alertas de incidentes. Com isso, é possível minimizar o tempo de resposta, fortalecer a infraestrutura digital nas comunidades menos abastadas e reduzir os riscos cibernéticos associados a interrupções de energia.

---

## ✅ Requisitos do Sistema
```bash
🔹 Requisitos Funcionais
✔️ Cadastro e consulta de regiões associadas aos dispositivos.
✔️ Cadastro e consulta de informações a respeito dos dispositivos de monitoramento.
✔️ Associação dos dispositivos instalados com as respectivas regiões monitoradas.
✔️ Registro manual de alertas ou via sistêmico a partir de consulta de rota.
✔️ Gerenciamento de usuários com autenticação JWT.
✔️ Gerenciamento de dispositivos IoT vinculados às regiões.
✔️ Geração de relatórios sobre alertas registrados.
✔️ Monitoramento da infraestrutura e da conexão com a base de dados.
✔️ Proteção das rotas que trafegam informações sensíveis.

🔹 Requisitos Não Funcionais
✔️ Desempenho otimizado com requisições assíncronas.
✔️ Segurança de acessos e do fluxo dos dados.
✔️ Escalabilidade, permitindo fácil expansão do sistema.
✔️ Armazenamento leve e eficiente.
✔️ Tolerância a falhas, garantindo robustez na aplicação.
✔️ Código modular, facilitando manutenção e extensões futuras.
```

---

## 🔄 Regras de Negócio
```bash
🚨 Gestão de Alertas
- Alertas podem ser registrados manualmente.
- Cada alerta deve estar associado a uma região cadastrada.
- O sistema pode gerar relatórios de ocorrências e identificar padrões críticos.
🔐 Controle de Usuários
- Apenas usuários autenticados podem ter acesso às funcionalidades de cadastro e consulta.
- Administradores têm acesso a relatórios e gestão de dispositivos.
📡 Gerenciamento de Dispositivos
- Cada dispositivo IoT deve ser vinculado a uma região específica de monitoramento.
- Os dispositivos enviam dados automaticamente para análise e resposta rápida.
```

---

## 🧩 Fluxogramas do Sistema
```bash
🚀 O sistema segue um fluxo estruturado para o registro e processamento de alertas:
1️º Recebimento de alerta via API ou dispositivo IoT
2️º Validação do alerta e associação à região correspondente
3️º Armazenamento no banco de dados de informações do alerta e da região
4️º Envio de notificações para sistemas conectados
5️º Geração de relatórios e análise de padrões, como resumo de todos os dispositivos e alertas configurados.

```
![Fluxograma](https://raw.githubusercontent.com/gui2604/BlackoutMonitorAPI/main/BlackoutMonitor.drawio.png)

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
## 📁 Estrutura de pastas
```bash
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
```

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
 	⚠️ Para realizar os testes não se esqueça de primeiro realizar o login e obter o token JWT! (instruções mais abaixo)
   ```

---
## 🌐 Endpoints

### 📌 Endpoints públicos
```bash
- POST /api/v1/auth/register – Cria novo usuário
- POST /api/v1/auth/login – Retorna token JWT
- GET /api/healthcheck – Health check público
```

### 🔐 Endpoints protegidos por autenticação JWT (requer token)
```bash
- GET /api/healthcheck/full - Consulta a saúde da aplicação e da conexão com o banco

- POST /api/v1/alerts - Cria um novo alerta
- GET /api/v1/report - Consulta o resumo das regioes e dos alertas atrelados

- POST /api/v1/devices - Cadastra um novo dispositivo
- GET /api/v1/by-region/{regionId} - Consulta os dispositivos instalados por regiao
- GET /api/v1/alerts - Consulta todos os dispositivos
- DELETE /api/v1/{id} - Deleta um dispositivo pelo seu id.

- GET /api/v1/region - Obtém as informações completas do endereço de um determinado CEP. Faz a consulta em cache, caso não exise faz a consulta online no ViaCEP.
```
---

## 🧪 Teste no Swagger
```bash
- 1. Faça login em /api/auth/login
	1.1 Utilize as credenciais:
		Email: professor@fiap.com.br
		Senha: 12345678
- 2. Copie o token retornado

- 3. Clique em Authorize no canto superior direito do Swagger

- Cole o token:
- Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

---

## 🐳 Executando com Docker
- docker pull gui2604/blackoutmonitorapi:1.0.0
- docker run --name container-blackoutmonitorapi -p 8080:8080 gui2604/blackoutmonitorapi:v1.0.0
