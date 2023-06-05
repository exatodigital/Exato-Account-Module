using ExatoDigital.OpenSource.AccountModule.Repository.Repositories;

namespace ExatoDigital.OpenSource.AccountModule.Repository.Memory
{
    public class MemoryAccountModuleRepositoryFactory : IAccountModuleRepositoryFactory
    {
        public IAccountModuleRepository Create()
        {
            return new MemoryAccountModuleRepository();
        }
    }
}
