using System;
using BankingApplication.Repositories;
using BankingApplication.Models;

namespace BankingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            allOperation repository = new allOperation();
            repository.allDetailList();
            repository.showAllDetails();

            char number;
            Console.WriteLine("Welcome to our Banking Application\n");
            do
            {
                Console.WriteLine("Press  1  to  Credit/debit using account number");
                Console.WriteLine("Press  2  to  Display balance using Account Number");
                Console.WriteLine("Press  3  to  Display balance for all the accounts using Customer ID");
                Console.WriteLine("Press  4  to  Display account statement using Account Number");
                var pressNumber = Console.ReadLine()[0];
                char pressNumber2;
                switch(pressNumber)
                {
                    case '1':
                        Console.WriteLine("Credit/debit using account number");
                        do
                        {
                            Console.WriteLine("Press D for Debit from your Account");
                            Console.WriteLine("Press C for Credit to your Account");
                            var pressNumber1 = char.ToUpper(Console.ReadLine()[0]);
                            switch(pressNumber1)
                            {
                                case 'D':
                                    repository.Debit();
                                    break;
                                case 'C':
                                    repository.Credit();
                                    break;
                                default:
                                    Console.WriteLine("Please enter valid option");
                                    break;
                            }
                            Console.WriteLine("Do you want to processed further transaction");
                            Console.WriteLine("Press Y for yes and press N for No");
                            pressNumber2 = char.ToUpper(Console.ReadLine()[0]);
                        } while (pressNumber2 == 'Y');
                        break;
                    case '2':
                        Console.WriteLine("Enter Account number to view your balance");
                        var accountNumber = Console.ReadLine();
                        repository.DisplayBalanceUsingAccountNumber(Guid.Parse(accountNumber));
                        break;
                    case '3':
                        Console.WriteLine("Enter Customer ID to view your all Details");
                        var customerId = Console.ReadLine();
                        repository.DisplayBalanceUsingCustomerId(Guid.Parse(customerId));
                        break;
                    case '4':
                        Console.WriteLine("Enter Account Number  To View your Account Statement");
                        var accountNumberForViewStatement = Console.ReadLine();
                        repository.ShowAccountStatement(Guid.Parse(accountNumberForViewStatement));
                        break;
                    default:
                        Console.WriteLine("no");
                        break;
                }
                Console.WriteLine("Do you want to Quit the application");
                Console.WriteLine("Press Y for yes and press N for No");
                number = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
            } while (number != 'Y');
        }


        
        }
}
