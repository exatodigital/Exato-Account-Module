using ExatoDigital.OpenSource.AccountModule.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
