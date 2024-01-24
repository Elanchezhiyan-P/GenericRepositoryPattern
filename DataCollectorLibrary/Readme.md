//Enable Migrations
- Enable-Migrations -ContextTypeName EmployeeContext -MigrationsDirectory Migrations\Employee

//Add Migrations
- Add-Migration -ConfigurationTypeName DataCollectorLibrary.Migrations.Employee.Configuration -Name Initial

//Update Database
- Update-Database -ConfigurationTypeName DataCollectorLibrary.Migrations.Employee.Configuration
