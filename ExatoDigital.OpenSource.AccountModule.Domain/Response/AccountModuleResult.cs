﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Response
{
    public class AccountModuleResult
    {
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
