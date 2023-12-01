# Garage
### Não configurado para compuse up

### Preparar banco de dados SQL Server em Docker:
Execute: `docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=123@456_abc" -p 1433:1433 --name sql_server -d mcr.microsoft.com/mssql/server:2022-latest`
Criar uma network para associar o gateway para a API: `docker network create --gateway=172.18.0.1 api_network`
Assinar a network com o container do SQL Server: `docker network connect api_network sql_server`
O banco de dados estará disponível em: `172.18.0.1,1433`, com autenticação SA

### Executar API:
Certificar de estar no diretório Garage/Garage/ com o PM Shell aberto, executar as migrações com `add-migration databasePrepear` & `update-database`

Em Garage/Garage/, executar `dotnet run` por CLI, expondo a API em http://localhost:5180

Para acessar a documentação por Swagger UI, acesse http://localhost:5180/swagger/index.html

### Consumir dados pela Web Page Asp Net:
Certificar de estar no diretório Garage/Domain/

Em Garage/Domain/, executar `dotnet run` por CLI, expondo a web page em http://localhost:5181
