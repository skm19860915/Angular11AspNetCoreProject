using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merchants.POC.USAePAY.Web.Models.CreateCreditCard
{
    interface ICreateCreditCardResponse
    {
        public string Key { get; set; }
        public string Type { get; set; }
        public string MethodName { get; set; }
        public string Expires { get; set; }
        public string CardType { get; set; }
        public string CcNum4Last { get; set; }
        public string AvsStreet { get; set; }
        public string AvsPostalCode { get; set; }
        public string SortOrd { get; set; }
        public string Added { get; set; }
        public string Updated { get; set; }
    }
}
