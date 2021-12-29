using System;
using BankingApplication.Repositories;
using BankingApplication.Models;

namespace BankingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            AllOperation repository = new AllOperation();
            repository.ShowDetails();
            repository.DisplayAllDetails();

            char number , number1 ,pressNumber2;
            Console.WriteLine("Welcome to our Banking Application\n");
            do
            {
                Console.WriteLine("Press  1  to  Credit/debit using account number");
                Console.WriteLine("Press  2  to  Display balance using Account Number");
                Console.WriteLine("Press  3  to  Display balance for all the accounts using Customer ID");
                Console.WriteLine("Press  4  to  Display account statement using Account Number");
                var pressNumber = Console.ReadLine()[0];
                switch(pressNumber)
                {
                    case '1':
                        Console.WriteLine("Credit/debit using account number");
                        do
                        {
                            Console.WriteLine("Press D for Debit from your Account");
                            Console.WriteLine("Press C for Credit to your Account");
                            Console.WriteLine("Press N if you want to Quit Debit/Credit operation");
                            char pressNumber1 = char.ToUpper(Console.ReadLine()[0]);
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

                            Console.WriteLine("Do you want to further processed For Debit/Credit Operation");
                            Console.WriteLine("Press Y for yes and press N for No");
                            pressNumber2 = char.ToUpper(Console.ReadLine()[0]);
                        } while (pressNumber2 == 'Y');
                        break;
                    case '2':
                        Console.WriteLine("Enter Account Number To View your Balance");
                        var AccountNumber = Console.ReadLine();
                        repository.DisplayBalanceUsingAccountNumber(Guid.Parse(AccountNumber));
                        break;
                    case '3':
                        Console.WriteLine("Enter Customer Id  To View All Account Balance");
                        Guid CustomerId;
                        string customerIdStr = Console.ReadLine();
                        while (!(Guid.TryParse(customerIdStr, out CustomerId)))
                        {
                            Console.WriteLine("Please Enter Customer Id in Correct format");
                            customerIdStr = Console.ReadLine();
                        }
                        repository.DisplayBalanceUsingCustomerId(CustomerId);
                        break;
                    case '4':
                        Console.WriteLine("Enter Account Number to View Account Statement");
                        Guid accountNumber;
                        string accountNumberStr = Console.ReadLine();
                        while (!(Guid.TryParse(accountNumberStr, out accountNumber)))
                        {
                            Console.WriteLine("Please Enter Account number in Correct format");
                            accountNumberStr = Console.ReadLine();
                        }
                        repository.ShowAccountStatement(accountNumber);
                        break;
                    default:
                        Console.WriteLine("Please enter valid option");
                        break;
                }
                Console.WriteLine("Do you want to Quit the application");
                Console.WriteLine("Press Y for yes and press N for No");
                number = Console.ReadKey().KeyChar;
                number1 = char.ToUpper(number);
                Console.WriteLine();
            } while (number1 != 'Y');
        }


        
        }
}
