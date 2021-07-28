﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lügavi.Models
{
    public class UserModel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        
        public AddressModel Adres { get; set; }
    }
}
