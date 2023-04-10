using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merchants.POC.USAePAY.Web.Models.CreateCreditCard
{
    public class CreateCreditCardRequest
    {
        public string Key { get; set; }
        public string Type { get; set; }
        public string  MethodName { get; set; }
        public string Expires { get; set; }
    }
}
