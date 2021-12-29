using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApplication.Models;

namespace BankingApplication.Repositories
{
    public class allOperation : IRepository
    {
        public static List<Customer> customer = new List<Customer>();


        public void showAllDetails()
        {
            foreach (var customer in customer)
            {
                Console.WriteLine($"CustomerName = {customer.customerName} \nCustomerId = {customer.customerId} \n");
                foreach (var account in customer.Accounts)
                {
                    Console.WriteLine($"AccountNumber - {account.AccountNumber}");
                    Console.WriteLine($"AccountBalance - {account.CurrentBalance}");
                    Console.WriteLine($"AccountType - {account.AccountType}");
                }
            }
        }

        public void Credit()
        {
            throw new NotImplementedException();
        }

        public static List<Transaction> transaction = new List<Transaction>();
        public void Debit()
        {
            Console.WriteLine("Enter CustomerId :-");
            var customerId = Console.ReadLine();
            Console.WriteLine("Enter AccountNumber :-");
            var accountNumber = Console.ReadLine();
            Console.WriteLine("Enter amount to be withdraw");
            var amount = Convert.ToInt32(Console.ReadLine());

            //amount filtering should be multiple of 100 and less than 50k per transaction
            if (amount % 100 == 0 && amount <= 50000)
            {
                //fetching Account using CustomerId and AccountNumber
                var AccountDetails = customer.First(x => x.customerId.ToString() == customerId).Accounts.First(y => y.AccountNumber.ToString() == accountNumber);
                //checking if withdrawl limit per hour and limit of number trasaction per hour exceed or not


                if (AccountDetails.WithdrawalLimitPerHour > 0 && AccountDetails.NumberOfTransactionPerHour >0)
                {
                    if(amount >= 30000)
                    {
                        AccountDetails.CurrentBalance = AccountDetails.CurrentBalance - (amount + 30);
                    }
                    else
                    {
                        AccountDetails.CurrentBalance = AccountDetails.CurrentBalance - amount;
                    }
                    
                    AccountDetails.WithdrawalLimitPerHour = AccountDetails.WithdrawalLimitPerHour - amount;
                    AccountDetails.NumberOfTransactionPerHour = AccountDetails.NumberOfTransactionPerHour - 1;
                    Console.WriteLine($"{amount} Successfully Debited From Account {AccountDetails.AccountNumber}");
                    AccountDetails.Transaction.Append(new Transaction() { Balance = AccountDetails.CurrentBalance, Amount = amount });
                    Console.WriteLine($"Current Balance: {AccountDetails.CurrentBalance}");
                }
                else
                {

                    Console.WriteLine("You Have Exceeded Your Limit");
                }
            }
            else
            {
                Console.WriteLine("Please Enter Amount In Multiple Of hundred");
            }


        }

        public void DisplayBalanceUsingCustomerId(Guid CustomerId)
        {
            var allList = customer.First(x => x.customerId == CustomerId).Accounts;
            foreach (var account in allList)
            {
                Console.WriteLine($"Account Number : {account.AccountNumber} has Current Balance : {account.CurrentBalance}");
            }
        }

        public void DisplayBalanceUsingAccountNumber(Guid AccountNumber)
        {
            var accountDetail = customer.Select
                (x => x.Accounts.FirstOrDefault(y => y.AccountNumber == AccountNumber));
            if (accountDetail != null)
            {
                foreach (var account in accountDetail)
                {
                    if (account != null)
                        Console.WriteLine($"Account Number : {AccountNumber} Has Current Balance : {account.CurrentBalance}");
                }
            }
        }

        public void ShowAccountStatement(Guid accountNumberForViewStatement)
        {
            var accountDetail = customer.Select
                (x => x.Accounts.FirstOrDefault(y => y.AccountNumber == accountNumberForViewStatement));
            if (accountDetail != null)
            {
                foreach (var account in accountDetail)
                {
                    if (account != null)
                    {
                        Console.WriteLine($"Account Number : {accountNumberForViewStatement} Has Current Balance : {account.CurrentBalance}");
                        foreach (var AllTransaction in account.Transaction)
                        {
                            Console.WriteLine("$Transaction Amount : {AllTransaction.AmountTransfer}");
                        }
                    }


                }
            }
        }


        double withdrawalLimitPerHour = 200000;
        int numberOfTransactionPerHour = 4;
        public void allDetailList()
        {
            customer.Add(new Customer()
            {
                customerId = Guid.NewGuid(),
                customerName = "Paras",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType ="Saving",
                        CurrentBalance = 164235,
                        LastTransactionTime = DateTime.Now,
                    },

                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Saving",
                        CurrentBalance = 200300,
                        LastTransactionTime = DateTime.Now,
                    }


                }
            });

            customer.Add(new Customer()
            {
                customerId = Guid.NewGuid(),
                customerName = "Kandarp",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Current",
                        CurrentBalance = 300542,
                        LastTransactionTime = DateTime.Now,
                    },
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Current",
                        CurrentBalance = 2136521,
                        LastTransactionTime = DateTime.Now,
                    },
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Saving",
                        CurrentBalance = 500000,
                        LastTransactionTime = DateTime.Now,
                    }
                }
            });

            customer.Add(new Customer()
            {
                customerId = Guid.NewGuid(),
                customerName = "Darsan",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Current",
                        CurrentBalance = 3754162,
                        LastTransactionTime = DateTime.Now,
                    },
                }
            });

            customer.Add(new Customer()
            {
                customerId = Guid.NewGuid(),
                customerName = "Maitri",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Current",
                        CurrentBalance = 1000000,
                        LastTransactionTime = DateTime.Now,
                    },
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Saving",
                        CurrentBalance = 2685942,
                        LastTransactionTime = DateTime.Now,
                    }
                }
            });

            customer.Add(new Customer()
            {
                customerId = Guid.NewGuid(),
                customerName = "Manishbhai",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Saving",
                        CurrentBalance = 6458923,
                        LastTransactionTime = DateTime.Now,
                    },
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Current",
                        CurrentBalance = 465287,
                        LastTransactionTime = DateTime.Now,
                    }
                }
            });
        }
    }
}
