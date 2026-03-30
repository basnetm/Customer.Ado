# Customer CRUD Application using ADO.NET

This is a simple console-based CRUD application built with C# and ADO.NET. It connects to SQL Server and performs basic database operations on the `CustomerInfo` table.

## Features

- Insert a new customer
- View all customers
- Search customer by name
- Update customer by Id
- Delete customer by Id

## Project Structure

The solution contains two projects:

### 1. Customer.Ado
This is the class library project that contains:

- `Customer.cs` → customer model
- `DAO.cs` → data access methods
- `SqlHandler.cs` → database connection and query execution
- `Sqls.cs` → SQL queries

### 2. Customer.Console.Client
This is the console application project that contains:

- `Program.cs` → menu-driven user interface for CRUD operations

## Technologies Used

- C#
- .NET
- ADO.NET
- SQL Server
- Microsoft.Data.SqlClient

## Database

Make sure you have a SQL Server database named:

```sql
Customer
