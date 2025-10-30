using System.Collections.Generic;

namespace ATM_Simulation_WebApp.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string CardNumber { get; set; } = default!;
        public string Pin { get; set; } = default!;
        public string Name { get; set; } = default!;
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; } = new();

        public Account() { }
    }
}
