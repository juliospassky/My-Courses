# GTSharp
## EF comandos

Lembrar de alterar no kitematic (na aba Hostname/Ports) o published ip:port para 1433

Instala o EFCore
```sh
dotnet tool install --global dotnet-ef
```
EFCore Adicionar Migration
```sh
dotnet ef migrations add InitialCreate --startup-project ..\GTSharp.Domain.Api\
```
EFCore Atualizar banco
```sh
dotnet ef database update  --startup-project ..\GTSharp.Domain.Api\  
```

## EF DataAnnotation
Caso for usar o EF com DataAnnotation deve instalar o pacote

Add Pacote DataAnnotation
```sh
dotnet add package System.ComponentModel.Annotations
```
