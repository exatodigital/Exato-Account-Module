using Exato_Account_Module.Domain.Return;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exato_Account_Module.Repository
{
    public class CreateAccountResponse : ICreateAccountResponse
    {
        public string Success { get; set; }

        public CreateAccountResponse(string success)
        {
            Success = success;
        }
    }
}
