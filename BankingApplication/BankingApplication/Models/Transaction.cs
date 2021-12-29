using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Models
{
    public class Transaction : Account
    {

        public string TransactionType 
        { 
            get; set; 
        }
        public int Amount 
        { 
            get; set; 
        }

        public int Balance 
        { 
            get; set; 
        }
    }
}
