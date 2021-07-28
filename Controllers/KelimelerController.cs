using Lügavi.Models;
using Lügavi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lügavi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KelimelerController : ControllerBase
    {

        public JsonKelimeService JsonKelimeService;
        public KelimelerController(JsonKelimeService jsonkelimeservice)
        {
            JsonKelimeService = jsonkelimeservice;
        }

        [HttpGet]
        public IEnumerable<KelimeModel> Get(string name)
        {
            if (name != null)
            {
                List<KelimeModel> list = new List<KelimeModel>();
                list.Add(JsonKelimeService.GetKelimeByName(name));
                IEnumerable<KelimeModel> en = list;
                return en;
            }
            else
            {
                return JsonKelimeService.GetKelimeler();
            }
        }
    }
}
