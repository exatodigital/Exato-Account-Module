﻿using ExatoDigital.OpenSource.AccountModule.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountTypeParameters
{
    public class UpdateAccountTypeParameters : AccountModuleParameters
    {
        public UpdateAccountTypeParameters(AccountType accountType)
        {
            AccountType = accountType;
        }
        public AccountType AccountType { get; set; }
    }
}