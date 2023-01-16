using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters
{
    public class CreateAccountTypeParameters
    {
        public CreateAccountTypeParameters(string name) 
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
