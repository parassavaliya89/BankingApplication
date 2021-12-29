﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApplication.Models;

namespace BankingApplication.Models
{
    public class Customer
    {
        public Guid customerId 
        { 
            get; set; 
        }
        public string customerName 
        { 
            get; set; 
        }
        public List<Account> Accounts 
        { 
            get; set; 
        }
    }
}
