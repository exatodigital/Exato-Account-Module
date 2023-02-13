using ExatoDigital.OpenSource.AccountModule.Core;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountTypeParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.CurrencyParameters;
using ExatoDigital.OpenSource.AccountModule.Repository.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
