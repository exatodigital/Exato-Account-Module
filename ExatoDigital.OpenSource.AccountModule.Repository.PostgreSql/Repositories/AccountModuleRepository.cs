using ExatoDigital.OpenSource.AccountModule.Domain.Parameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response;
using ExatoDigital.OpenSource.AccountModule.Repository.Repositories;

namespace ExatoDigital.OpenSource.AccountModule.Repository.PostgreSql.Repositories
{
    public sealed class AccountModuleRepository : IAccountModuleRepository
    {
        private readonly AccountModuleDbContext _dbContext;
        public AccountModuleRepository(AccountModuleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public AccountModuleDbContext DbContext => _dbContext;

        public async Task<CreateAccountResult> CreateAccount(CreateAccountParameters parameters)
        { 
            return new CreateAccountResult();
        }
        public async Task<BlockUserBalanceResult> BlockUserBalance(BlockUserBalanceParameters parameters)
        {
            return new BlockUserBalanceResult();
        }
    }
}
