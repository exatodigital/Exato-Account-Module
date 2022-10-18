using Exato_Account_Module.Domain.Return;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exato_Account_Module.Repository
{
    public class CreateAccountReturn : ICreateAccountResponse
    {
        public string Success { get; set; }

        public CreateAccountReturn(string success)
        {
            Success = success;
        }
    }
}
