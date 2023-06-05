using ExatoDigital.OpenSource.AccountModule.Core;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.UserBalanceParameters;
using ExatoDigital.OpenSource.AccountModule.Repository.PostgreSql;
using ExatoDigital.OpenSource.AccountModule.Repository.PostgreSql.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var parameter = new BlockUserBalanceParameters(1, 10);
            var result = await module.BlockUserBalance(parameter);

            Assert.IsNull(result);
        }
    }
}
