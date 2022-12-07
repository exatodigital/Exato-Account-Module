using ExatoDigital.OpenSource.AccountModule.Core;
using ExatoDigital.OpenSource.AccountModule.Domain;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters;
using ExatoDigital.OpenSource.AccountModule.Repository.PostgreSql;
using ExatoDigital.OpenSource.AccountModule.Repository.PostgreSql.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Tests.UserBlockBalanceTests
{
    [TestClass]
    public class UserBlockBalanceTests
    {
        [TestMethod]
        public async void Block_User()
        {
            var db = new AccountModuleDbContext("connectionString");
            // Criando factory de repositorios
            var repositoryFactory = new AccountModuleRepositoryFactory(db);
            //Criando fachada
            var module = new AccountModuleFacade(repositoryFactory);
            // Chamando um método
            var parameter = new BlockUserBalanceParameters();
            var result = await module.BlockUserBalance(parameter);

            Assert.IsNull(result);
        }
    }
}
