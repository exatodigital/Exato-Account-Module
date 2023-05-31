using ExatoDigital.OpenSource.AccountModule.Core;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountTypeParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.CurrencyParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.UserBalanceParameters;
using ExatoDigital.OpenSource.AccountModule.Repository.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Tests.TransactionTests
{
    [TestClass]
    public class TransactionBalanceTests
    {
        private AccountModuleFacade _accountModuleFacade = null!;

        [TestInitialize]
        public void TestInitialize()
        {
            MemoryAccountModuleRepository.Clear();
            var factory = new MemoryAccountModuleRepositoryFactory();
            _accountModuleFacade = new AccountModuleFacade(factory);
        }
        [TestMethod]
        public async Task TransferBalanceSuccess()
        {
            // Criando AccountType
            var createAccountTypeParams = new CreateAccountTypeParameters("Conta");
            var accountType = await _accountModuleFacade.CreateAccountType(createAccountTypeParams);
            // Criando Currency
            var createCurrencyParams = new CreateCurrencyParameters("Créditos", "Créditos", "Créditos", null, 2, 1, 100000000, "CRED");
            var currency = await _accountModuleFacade.CreateCurrency(createCurrencyParams);
            //Criando AccountOne
            var createAccountParams = new CreateAccountParameters("Exato", "Exato Digital", "Exato", null, null, 10, null, null, currency.currency.CurrencyId, accountType.accountType.AccountTypeId);
            var createAccountSender = await _accountModuleFacade.CreateAccount(createAccountParams);

            //Criando AccountTwo
            var createAccountParams2 = new CreateAccountParameters("Exato2", "Exato Digital2", "Exato2", null, null, 10, null, null, currency.currency.CurrencyId, accountType.accountType.AccountTypeId);
            var createAccountReceiver = await _accountModuleFacade.CreateAccount(createAccountParams2);

            //Criando Transaction
            var TransferBalanceParameters = new TransferBalanceParameters(createAccountSender.Account.AccountId, createAccountReceiver.Account.AccountId, 10);
            var createTransaction = await _accountModuleFacade.TransferBalance(TransferBalanceParameters);

            Assert.IsTrue(createTransaction.Success);
        }
    }
}
