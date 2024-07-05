# LocalForecast53

Este projeto é um sistema de previsão do tempo que faz previsões para os próximos 5 dias (com passo de 3 horas) com base na localização atual do usuário. Ele é dividido em dois componentes principais: uma API backend desenvolvida em .NET Core 8 e um frontend desenvolvido em Angular.

## Estrutura do Projeto
- `backend/`: Contém o código da API.
- `frontend/`: Contém o código do frontend.
- `db-init/`: Contém script de criação do banco de dados usado na inicialização do container.

## Configuração do Ambiente

### Pré-requisitos
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

### Subindo a Aplicação

1. Clone este repositório:
   ```sh
   git clone https://github.com/fmagalhaesjunior/LocalForecast53.git
   
2. Navegue até o diretório raiz do projeto:
  `cd LocalForecast53`

3. Inicie os containers Docker:
`docker-compose up --build`

4. A aplicação estará disponível em:
   - Backend API: `http://localhost:8080`
   - Frontend: `http://localhost`
