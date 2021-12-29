
using System;

namespace BankingApplication.Repositories
{
    public interface IMethod
    {
        void DisplayBalanceUsingCustomerId(Guid CustomerId);
        void DisplayBalanceUsingAccountNumber(Guid AccountNumber);
        void ShowAccountStatement(Guid accountNumberForShowAccountStatement);
        void Credit();
        void Debit();
    }
}