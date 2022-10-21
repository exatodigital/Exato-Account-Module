using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exato_Account_Module.Domain.Repository
{
    public interface IAccountTypeRepository
    {
        void CreateAccountType();
        void UpdateAccountType();
        void DeleteAccountType();
        void ListAccountType();
    }
}
