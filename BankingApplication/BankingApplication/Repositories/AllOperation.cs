using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApplication.Models;

namespace BankingApplication.Repositories
{
    public class AllOperation : IMethod
    {
        public static List<Customer> customer = new List<Customer>();
        

        int WithdrawalLimitPerHour = 200000;
        int NumberOfTransactionPerHour = 4;

        public void DisplayAllDetails()
        {
            foreach (var customer in customer)
            {
                int index = 1;
                Console.WriteLine($"CustomerName - {customer.CustomerName}");
                Console.WriteLine($"Customer ID - {customer.CustomerId}");
                foreach (var account in customer.Accounts)
                {
                    Console.WriteLine($"({index}) - AccountNumber - {account.AccountNumber}");
                    Console.WriteLine($"AccountBalance - {account.CurrentBalance}");
                    Console.WriteLine($"AccountType - {account.AccountType}");
                    Console.WriteLine("");
                    index++;
                }
            }
        }

        public void Debit()
        {
            Console.WriteLine("Enter your CustomerId");
            var customerId = Console.ReadLine();

            Console.WriteLine("Enter your AccountNumber");
            var accountNumber = Console.ReadLine();

            Console.WriteLine("Enter amount you want to withdraw in your Account");
            var amount = Convert.ToInt32(Console.ReadLine());



            if((amount % 100) == 0)
            {
                if(amount <= 50000)
                {
                    var AccountDetails = customer.FirstOrDefault(x => x.CustomerId.ToString() == customerId).Accounts.FirstOrDefault(y => y.AccountNumber.ToString() == accountNumber);
                    TimeSpan Ts = DateTime.Now - AccountDetails.LastTransactionTime;
                    if (Ts.Hours >= 1)
                    {
                        AccountDetails.NumberOfTransactionPerHour = 4;
                        AccountDetails.WithdrawalLimitPerHour = 200000;
                    }
                    if (AccountDetails.NumberOfTransactionPerHour > 0 && AccountDetails.WithdrawalLimitPerHour >0 )
                    {
                        if(amount > 30000)
                        {
                            AccountDetails.CurrentBalance = AccountDetails.CurrentBalance - (amount + 30);
                            AccountDetails.WithdrawalLimitPerHour -= (amount + 30);

                            AccountDetails.NumberOfTransactionPerHour -= 1;
                            DateTime CurrentTime = DateTime.Now;
                            AccountDetails.LastTransactionTime = CurrentTime;
                            Console.WriteLine($"{amount} Successfully Debited from your Account {AccountDetails.AccountNumber}");
                            
                            AccountDetails.Transactions.Add(new Transaction() { Amount = amount, Balance = AccountDetails.CurrentBalance, });
                            Console.WriteLine($"Current Balance: {AccountDetails.CurrentBalance}");
                        }
                        else
                        {
                            AccountDetails.CurrentBalance = AccountDetails.CurrentBalance - amount;
                            AccountDetails.NumberOfTransactionPerHour -= 1;
                            AccountDetails.WithdrawalLimitPerHour -= amount;
                            DateTime CurrentTime = DateTime.Now;
                            AccountDetails.LastTransactionTime = CurrentTime;
                            Console.WriteLine($"{amount} Successfully Debited from Account {AccountDetails.AccountNumber}");
                           
                            AccountDetails.Transactions.Add(new Transaction() { Amount = amount, Balance = AccountDetails.CurrentBalance });
                            Console.WriteLine($"Current Balance: {AccountDetails.CurrentBalance}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have exceed your hourly limit");
                    }
                }
                else
                {
                    Console.WriteLine("You can only withdraw less than or equal to 50k");
                }
            }
            else
            {
                Console.WriteLine("You can  withdraw in multiple of hundred");
            }
        }

        public void Credit()
        {
            Console.WriteLine("Enter your CustomerId");
            var customerId = Console.ReadLine();
            Console.WriteLine("Enter your AccountNumber");
            var accountNumber = Console.ReadLine();
            Console.WriteLine("Enter amount you want to credit in your Account");
            var amount = Convert.ToInt32(Console.ReadLine());


            var AccountDetails = customer.FirstOrDefault(x => x.CustomerId.ToString() == customerId).Accounts.FirstOrDefault(y => y.AccountNumber.ToString() == accountNumber);
            TimeSpan Ts = DateTime.Now - AccountDetails.LastTransactionTime;
            if (Ts.Hours >= 1)
            {
                AccountDetails.NumberOfTransactionPerHour = 4;
                AccountDetails.WithdrawalLimitPerHour = 200000;
            }
            if (AccountDetails.NumberOfTransactionPerHour > 0)
            {
                if((amount % 100) == 0)
                {
                    AccountDetails.CurrentBalance = AccountDetails.CurrentBalance + amount;
                    AccountDetails.NumberOfTransactionPerHour -= 1;
                    Console.WriteLine($"{amount} Successfully Debited from Account {AccountDetails.AccountNumber}");
                    AccountDetails.Transactions.Add(new Transaction() { Amount = amount, Balance = AccountDetails.CurrentBalance });
                    Console.WriteLine($"Current Balance: {AccountDetails.CurrentBalance}");
                }
                else
                {
                    Console.WriteLine("You can debit only in multiple of hundred");
                }
            }
            else
            {
                Console.WriteLine("You can not proceed more than 4 transaction in an hour");
            }



        }

        public void DisplayBalanceUsingCustomerId(Guid CustomerId)
        {
            var allAccountsDetail = customer.FirstOrDefault(x => x.CustomerId == CustomerId);
            if(allAccountsDetail!= null)
            {
                int index = 0;
                foreach (var account in allAccountsDetail.Accounts)
                {
                    Console.WriteLine($"{index}Account Number - {account.AccountNumber}");
                    Console.WriteLine($"Current Balance - {account.CurrentBalance}");
                    Console.WriteLine("");
                    index++;
                }
            }
        }

        public void DisplayBalanceUsingAccountNumber(Guid AccountNumber)
        {
            var accountDetail = customer.Select(x => x.Accounts.FirstOrDefault(y => y.AccountNumber == AccountNumber));
            if (accountDetail != null)
            {
                foreach (var account in accountDetail)
                {
                    if (account != null)
                    {
                        Console.WriteLine($"Account Number - {AccountNumber}");
                        Console.WriteLine($"Current Balance - {account.CurrentBalance}");
                    }
                }
            }
        }

        public void ShowAccountStatement(Guid accountNumberForShowAccountStatement)
        {
            var accountDetail = customer.Select
                (x => x.Accounts.FirstOrDefault(y => y.AccountNumber == accountNumberForShowAccountStatement));
            if (accountDetail != null)
            {
                int index = 0;
                foreach (var account in accountDetail)
                {
                    if (account != null)
                    {
                        Console.WriteLine($"{index}Account Number : {accountNumberForShowAccountStatement} Has Current Balance : {account.CurrentBalance}");
                        foreach (var AllTransaction in account.Transactions)
                        {
                            Console.WriteLine($"Transaction Amount : {AllTransaction.Amount} \n Current Balance : {AllTransaction.Balance}");
                        }
                        index++;
                        Console.WriteLine();
                    }


                }
            }
        }

        
        public void ShowDetails()
        {
            customer.Add(new Customer()
            {
                CustomerId = Guid.NewGuid(),
                CustomerName = "Paras",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Saving",
                        CurrentBalance = 100254,
                        LastTransactionTime = DateTime.Now,
                        WithdrawalLimitPerHour = WithdrawalLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour
                    },

                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Current",
                        CurrentBalance = 263589,
                        LastTransactionTime = DateTime.Now,
                        WithdrawalLimitPerHour = WithdrawalLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour
                    },

                }
            }) ;

            customer.Add(new Customer()
            {
                CustomerId = Guid.NewGuid(),
                CustomerName = "Kandarp",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Current",
                        CurrentBalance = 8546975,
                        LastTransactionTime = DateTime.Now,
                        WithdrawalLimitPerHour = WithdrawalLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour
                    },
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Saving",
                        CurrentBalance = 643827,
                        LastTransactionTime = DateTime.Now,
                        WithdrawalLimitPerHour = WithdrawalLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour
                    },

                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Current",
                        CurrentBalance = 89000000,
                        LastTransactionTime = DateTime.Now,
                        WithdrawalLimitPerHour = WithdrawalLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour
                    }
                }
            });

            customer.Add(new Customer()
            {
                CustomerId = Guid.NewGuid(),
                CustomerName = "Darshan",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Saving",
                        CurrentBalance = 6435272,
                        LastTransactionTime = DateTime.Now,
                        WithdrawalLimitPerHour = WithdrawalLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour
                    },
                    

                }
            });

            customer.Add(new Customer()
            {
                CustomerId = Guid.NewGuid(),
                CustomerName = "Maitri",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Current",
                        CurrentBalance = 3124567,
                        LastTransactionTime = DateTime.Now,
                        WithdrawalLimitPerHour = WithdrawalLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour
                    },

                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Current",
                        CurrentBalance = 9657849,
                        LastTransactionTime = DateTime.Now,
                        WithdrawalLimitPerHour = WithdrawalLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour
                    }
                }
            });

            customer.Add(new Customer()
            {
                CustomerId = Guid.NewGuid(),
                CustomerName = "Manishbhai",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = "Saving",
                        CurrentBalance = 3124658,
                        LastTransactionTime = DateTime.Now,
                        WithdrawalLimitPerHour = WithdrawalLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour
                    }
                }
            });
        }
    }
}
