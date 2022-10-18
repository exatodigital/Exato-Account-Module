using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exato_Account_Module.Domain.Repository
{
    public interface IAccountRepository
    {
        void Create();
        void Edit();
        void Delete(int id);
        void List();
    }
}
