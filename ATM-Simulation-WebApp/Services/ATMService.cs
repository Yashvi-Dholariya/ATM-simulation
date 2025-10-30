using System;
using System.Collections.Generic;
using System.Linq;
using ATM_Simulation_WebApp.Models;

namespace ATM_Simulation_WebApp.Services
{
    public class ATMService
    {
        private static readonly List<Account> _accounts;

        static ATMService()
        {
            // Initialize the static list of accounts
            _accounts = new List<Account>
            {
                new Account
                {
                    Id = 1,
                    CardNumber = "1111222233334444",
                    Pin = "1234",
                    Name = "Yashvi Dholariya",
                    Balance = 15000m,
                    Transactions = new List<Transaction>
                    {
                        new Transaction { Date = DateTime.Now.AddDays(-5), Type = "Deposit", Amount = 10000m, BalanceAfter = 15000m, Description = "Initial deposit" }
                    }
                },
                new Account
                {
                    Id = 2,
                    CardNumber = "4444333322221111",
                    Pin = "0000",
                    Name = "Test User",
                    Balance = 5000m,
                    Transactions = new List<Transaction>()
                }
            };
        }

        public ATMService()
        {
            // Constructor is now empty since we initialize in the static constructor
        }

        public Account? Authenticate(string cardNumber, string pin)
        {
            // Remove any spaces from the input card number for comparison
            var cleanCardNumber = cardNumber?.Replace(" ", "") ?? string.Empty;
            
            return _accounts.FirstOrDefault(a => 
                (a.CardNumber?.Replace(" ", "") == cleanCardNumber) && 
                a.Pin == pin);
        }

        public Account? GetByCard(string cardNumber)
        {
            return _accounts.FirstOrDefault(a => a.CardNumber == cardNumber);
        }

        public IEnumerable<Transaction> GetTransactions(Account account)
        {
            return account.Transactions.OrderByDescending(t => t.Date);
        }

        public void Deposit(Account account, decimal amount, string? description = null)
        {
            if (amount <= 0) throw new ArgumentException("Deposit amount must be positive.");
            account.Balance += amount;
            account.Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Type = "Deposit",
                Amount = amount,
                BalanceAfter = account.Balance,
                Description = description
            });
        }

        public List<Account> GetAllAccounts()
        {
            return _accounts;
        }

        public void Withdraw(Account account, decimal amount, string? description = null)
        {
            if (amount <= 0) throw new ArgumentException("Withdrawal amount must be positive.");
            if (account.Balance < amount) throw new InvalidOperationException("Insufficient balance.");
            account.Balance -= amount;
            account.Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Type = "Withdraw",
                Amount = amount,
                BalanceAfter = account.Balance,
                Description = description
            });
        }

        // Debugging method to get all accounts
    }
}
