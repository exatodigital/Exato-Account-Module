using ExatoDigital.OpenSource.AccountModule.Core;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.CurrencyParameters;
using ExatoDigital.OpenSource.AccountModule.Repository.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Tests.CurrencyTests
{
    [TestClass]
    public class CurrencyTests
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
        public async Task RetrieveCurrencySuccess()
        {
            var createCurrencyParams = new CreateCurrencyParameters("Créditos", "Créditos", "Créditos", null, 2, 1, 100000000, "CRED");
            await _accountModuleFacade.CreateCurrency(createCurrencyParams);
            var retrieveCurrencyParameters = new RetrieveCurrencyParameters(currencyId: 1);
            var retrieveCurrency = await _accountModuleFacade.RetrieveCurrency(retrieveCurrencyParameters);
            Assert.IsTrue(retrieveCurrency.Success);
        }
        [TestMethod]
        public async Task UpdateCurrencySuccess()
        {
            var createCurrencyParams = new CreateCurrencyParameters("Créditos", "Créditos", "Créditos", null, 2, 1, 100000000, "CRED");
            var result = await _accountModuleFacade.CreateCurrency(createCurrencyParams);
            result.currency.ShortDisplayName = "Mudei o nome";
            var updateCurrencyParameters = new UpdateCurrencyParameters(currency: result.currency);
            var updateCurrency = await _accountModuleFacade.UpdateCurrency(updateCurrencyParameters);
            Assert.IsTrue(updateCurrency.Success);
        }
        [TestMethod]
        public async Task DeleteCurrencySuccess()
        {
            var createCurrencyParams = new CreateCurrencyParameters("Créditos", "Créditos", "Créditos", null, 2, 1, 100000000, "CRED");
            var result = await _accountModuleFacade.CreateCurrency(createCurrencyParams);
            var deleteCurrencyParameters = new DeleteCurrencyParameters(currencyId: result.currency.CurrencyId, null);
            var deleteCurrency = await _accountModuleFacade.DeleteCurrency(deleteCurrencyParameters);
            Assert.IsTrue(deleteCurrency.Success);
        }
    }
}
