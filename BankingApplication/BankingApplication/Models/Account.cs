using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Models
{
    
    public class Account : Customer
    {
        public Account()
        {
            Transaction = new List<Transaction>();
        }

        public string AccountType 
        { 
            get; set;
        }
        public Guid AccountNumber
        { 
            get; set; 
        }
        public int CurrentBalance 
        { 
            get; set; 
        }
        public int WithdrawalLimitPerHour 
        { 
            get; set; 
        }
        public DateTime LastTransactionTime 
        { 
            get; set; 
        }
        public int NumberOfTransactionPerHour
        {
            get;set;
        }

        public List<Transaction> Transaction 
        { 
            get; set; 
        }

    }
}
