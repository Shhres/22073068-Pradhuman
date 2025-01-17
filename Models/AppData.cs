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

        public List<Transaction> GetTransactionsForUser(Guid userId)
        {
            return Transactions.Where(t => t.UserId == userId).ToList();
        }


        public List<Debt> Debts { get; set; } = new();

        // Method to add a debt
        public void AddDebt(Debt debt)
        {
            Debts.Add(debt);
        }
        // Method to get the highest transaction (by Credit)
        public Transaction? GetHighestTransaction()
        {
            return Transactions.OrderByDescending(t => t.Credit).FirstOrDefault();
        }

        // Method to get the lowest transaction (by Debit)
        public Transaction? GetLowestTransaction()
        {
            return Transactions.OrderBy(t => t.Debit).FirstOrDefault();
        }

    }
}

