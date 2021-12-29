
using System;

namespace BankingApplication.Repositories
{
    public interface IRepository
    {
        void DisplayBalanceUsingCustomerId(Guid CustomerId);
        void DisplayBalanceUsingAccountNumber(Guid accountNumberForDisplayBalance);
        void ShowAccountStatement(Guid accountNumberForViewStatement);
        void Credit();
        void Debit();
    }
}