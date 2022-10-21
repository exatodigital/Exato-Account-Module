using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exato_Account_Module.Domain.Repository
{
    public interface ITransactionRepository
    {
        void CreditAccount();
        void DebitAccount();
        void ListAllTransactions();
        void ListLast30DaysTransactions();
        void ListLast60DaysTransactions();
        void ListLast90DaysTransactions();
        void ListTransactionsCustomDays();
    }
}
