using ExatoDigital.OpenSource.AccountModule.Core;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountTypeParameters;
using ExatoDigital.OpenSource.AccountModule.Repository.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExatoDigital.OpenSource.AccountModule.Tests.AccountTypeTests
{
    [TestClass]
    public class AccountTypeTests
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
        public async Task CreateAccountTypeSuccess()
        {
            var createAccountTypeParams = new CreateAccountTypeParameters("Teste");
            var createAccountType = await _accountModuleFacade.CreateAccountType(createAccountTypeParams);
            Assert.IsTrue(createAccountType.Success);
        }
        [TestMethod]
        public async Task RetrieveAccountTypeSuccess()
        {
            var createAccountTypeParams = new CreateAccountTypeParameters("Teste");
            var createAccountType = await _accountModuleFacade.CreateAccountType(createAccountTypeParams);
            if (createAccountType.Success)
            {
                var retrieveAccountTypeParameters = new RetrieveAccountTypeParameters(1);
                var retrieveAccountType = await _accountModuleFacade.RetrieveAccountType(retrieveAccountTypeParameters);
                Assert.IsTrue(retrieveAccountType.Success);
            }
            else
                Assert.IsFalse(true);
        }
        [TestMethod]
        public async Task UpdatAccountTypeSuccess()
        {
            var createAccountTypeParameters = new CreateAccountTypeParameters("Teste");
            var result = await _accountModuleFacade.CreateAccountType(createAccountTypeParameters);
            result.accountType.Name = "Mudei o nome";
            var updateAccountTypeParameters = new UpdateAccountTypeParameters(accountType: result.accountType);
            var updateAccountType = await _accountModuleFacade.UpdateAccountType(updateAccountTypeParameters);
            Assert.IsTrue(updateAccountType.Success);
        }
    }
}
