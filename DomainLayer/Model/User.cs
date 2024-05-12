﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class    User: BaseClass
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double PhoneNumber { get; set; }
        public string Role { get; set; }
        public ICollection<DailyLog> DailyLogs { get; set; }

    }
}
