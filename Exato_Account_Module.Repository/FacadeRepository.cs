using Exato_Account_Module.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exato_Account_Module.Repository
{

    public class Facade : IFacade
        {
            private readonly IAccountRepository _accountRepository;
            private readonly IAccountTypeRepository _accountTypeRepository;
            private readonly ICurrencyRepository _currencyRepository;
            private readonly ITransactionRepository _transactionRepository;

            public Facade(IAccountRepository accountRepository, IAccountTypeRepository accountTypeRepository, ICurrencyRepository currencyRepository, ITransactionRepository transactionRepository)
            {
                _accountRepository = accountRepository;
                _accountTypeRepository = accountTypeRepository;
                _currencyRepository = currencyRepository;
                _transactionRepository = transactionRepository;
            }
            public void CreateAccount()
            {
                return;
            }
        }

}
