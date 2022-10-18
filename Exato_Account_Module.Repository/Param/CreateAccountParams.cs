using Exato_Account_Module.Domain.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exato_Account_Module.Repository
{
    public class CreateAccountParams : ICreateAccountParams
    {
        public string Name { get; set; }

        public CreateAccountParams(string name)
        {
            Name = name;
        }
    }
}
