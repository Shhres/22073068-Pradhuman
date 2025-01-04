using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MauiApp1.Models
{
    public class AppData
    {
        public List<User> Users { get; set; } = new();
        public List<Transaction> Transactions { get; set; } = new();

        // Add Balance and LoanAmount properties
        public decimal Balance { get; set; } = 0m;  // Initialize with a default value if needed
        public decimal PendingLoanAmount { get; set; } = 0m;
        // Initialize with a default value if needed
    }
}
