using ExatoDigital.OpenSource.AccountModule.Repository.Repositories;


namespace ExatoDigital.OpenSource.AccountModule.Repository.PostgreSql.Repositories
{
    public class AccountModuleRepositoryFactory : IAccountModuleRepositoryFactory
    {
        private readonly AccountModuleDbContext _dbContext;

        public AccountModuleRepositoryFactory(AccountModuleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IAccountModuleRepository Create()
        {
            return new AccountModuleRepository(_dbContext);
        }
    }
}
