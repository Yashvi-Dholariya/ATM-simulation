using System;

namespace ATM_Simulation_WebApp.Models
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Type { get; set; } = default!; // "Deposit" or "Withdraw"
        public decimal Amount { get; set; }
        public decimal BalanceAfter { get; set; }
        public string? Description { get; set; }
    }
}
