using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdventureWorksWebAPI.Controllers
{
    public class Math
    {
        public int variable1 { get; set; }
        public int variable2 { get; set; }
    }

    public class BindingController : ApiController
    {
        [HttpGet]
        public int Add(int var1, int var2)
        {
            return var1 + var2;
        }

        [HttpPost]
        public int Subtract(int var1, [FromBody] int var2)
        {
            return var1 - var2;
        }

        [HttpPost]
        public int Multiply(Math math)
        {
            return math.variable1 * math.variable2;
        }

        [HttpGet]
        public int Divide([FromUri] Math math)
        {
            if (math.variable2 == 0) return 0;
            return math.variable1 / math.variable2;
        }
    }
}
