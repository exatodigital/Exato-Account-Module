using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Repository.Repositories
{
    public interface IAccountModuleRepositoryFactory
    {
        public IAccountModuleRepository Create();
    }
}
