# Comando úteis
Criar migrações
```shell
dotnet ef migrations add <value>
```
Atualizar o banco
```shell
dotnet ef database update
```
Remove a última migration
```shell
dotnet ef migrations remove
```

| Command | Usage |
| :--- | :--- |
| `dotnet ef --help` | Displays information about Entity Framework commands. |
| `dotnet ef database drop` | Drops the database. |
| `dotnet ef database update` | Updates the database to the last migration or to a specified migration. |
| `dotnet ef dbcontext info` | Gets information about a `DbContext` type. |
| `dotnet ef dbcontext list` | Lists available `DbContext` types. |
| `dotnet ef dbcontext optimize` | Generates a compiled version of the model used by the `DbContext`. |
| `dotnet ef dbcontext scaffold` | Generates a `DbContext` and entity type classes for a specified database. |
| `dotnet ef dbcontext script` | Generates a SQL script from the `DbContext`. Bypasses any migrations. |
| `dotnet ef migrations add` | Adds a new migration. |
| `dotnet ef migrations bundle` | Creates an executable to update the database. |
| `dotnet ef migrations has-pending-model-changes` | Checks if any changes have been made to the model since the last migration. |
| `dotnet ef migrations list` | Lists available migrations. |
| `dotnet ef migrations remove` | Removes the last migration. |
| `dotnet ef migrations script` | Generates a SQL script from the migrations. |