using ExatoDigital.OpenSource.AccountModule.Core;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountTypeParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.CurrencyParameters;
using ExatoDigital.OpenSource.AccountModule.Repository.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExatoDigital.OpenSource.AccountModule.Tests.AccountTests
{
    [TestClass]
    public class AccountTests
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
        public async Task CreateAccountSuccess()
        {
            // Criando AccountType
            var createAccountTypeParams = new CreateAccountTypeParameters("Conta");
            var accountType = await _accountModuleFacade.CreateAccountType(createAccountTypeParams);
            // Criando Currency
            var createCurrencyParams = new CreateCurrencyParameters("Créditos", "Créditos", "Créditos", null, 2, 1, 100000000, "CRED");
            var currency = await _accountModuleFacade.CreateCurrency(createCurrencyParams);

            //Criando Account
            var createAccountParams = new CreateAccountParameters("Exato", "Exato Digital", "Exato",null,null , 10 , null,null, currency.currency.CurrencyId, accountType.accountType.AccountTypeId);
            var createAccount = await _accountModuleFacade.CreateAccount(createAccountParams);
            Assert.IsTrue(createAccount.Success);
        }
    }
}
