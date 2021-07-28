using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lügavi.Models
{
    public class KelimeModel
    {
        public int id { get; set; }
        public string KelimeAdi { get; set; }
        public string Anlam { get; set; }
        public string Dil { get; set; }
        public string Ornek { get; set; }

    }
}
