# ATM Simulation Web Application

A modern, responsive web application that simulates ATM operations, built with ASP.NET Core and Bootstrap 5.

![ATM Simulation Demo](https://img.shields.io/badge/Status-Live-success)
![.NET Version](https://img.shields.io/badge/.NET-6.0-blue)
![License](https://img.shields.io/badge/License-MIT-green)

## 📋 Description

This ATM Simulation Web Application provides a realistic online banking experience with essential ATM functionalities. Users can perform various banking operations such as checking balances, making deposits, withdrawing money, and viewing transaction history in a secure and user-friendly interface.

## Features

- **User Authentication**
  - Secure login with card number and PIN
  - Demo accounts available for testing
  - Session management and security

- **Account Operations**
  - Check account balance
  - Deposit money into account
  - Withdraw money from account
  - View detailed transaction history
  - Print transaction receipts

- **User Experience**
  - Responsive design works on all devices
  - Intuitive and clean interface
  - Real-time feedback and validation
  - Secure session management

## Demo Accounts

| Card Number     | PIN  | Account Holder    |
|-----------------|------|-------------------|
| 1111 2222 3333 4444 | 1234 | Yashvi Dholariya |
| 4444 3333 2222 1111 | 0000 | Test User        |

## Technologies Used

- **Backend**: ASP.NET Core 6.0
- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap 5
- **Icons**: Bootstrap Icons
- **Database**: SQL Server (LocalDB)
- **Authentication**: ASP.NET Core Identity
- **Deployment**: Self-hosted

## Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:
- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (with ASP.NET and web development workload) or [VS Code](https://code.visualstudio.com/)
- [SQL Server Express LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/Yashvi-Dholariya/ATM-Simulation.git
   cd ATM-Simulation-WebApp
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Update the database**
   ```bash
   dotnet ef database update
   ```
   
4. **Run database migrations** (if any)
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

### Running the Application

#### Using Visual Studio:
1. Open the solution file `ATM-Simulation-WebApp.sln` in Visual Studio
2. Press `F5` or click the "Start" button to run the application
3. The application will open in your default web browser at `https://localhost:5001`

#### Using .NET CLI:
```bash
dotnet run --project ATM-Simulation-WebApp
```
Then open your browser and navigate to `https://localhost:5001`
