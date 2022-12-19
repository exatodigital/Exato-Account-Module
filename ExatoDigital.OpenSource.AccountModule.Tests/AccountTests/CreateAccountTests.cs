using ExatoDigital.OpenSource.AccountModule.Core;
using ExatoDigital.OpenSource.AccountModule.Domain;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response;
using ExatoDigital.OpenSource.AccountModule.Repository.Memory;
using ExatoDigital.OpenSource.AccountModule.Repository.PostgreSql;
using ExatoDigital.OpenSource.AccountModule.Repository.PostgreSql.Repositories;
using ExatoDigital.OpenSource.AccountModule.Repository.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Tests.AccountTests
{
    [TestClass]
    public class CreateAccountTests
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
        public void CreateAccount()
        {
            var createAccountParams = new CreateAccountParameters("Exato", "Exato Digital", "Exato",null,null , 10 , null,null, accountTypeId: 1, currencyId: 1);
            var createAccount = _accountModuleFacade.CreateAccount(createAccountParams);
            Assert.IsTrue(createAccount.Result.Success);
        }
    }
}
