using System;
using System.Collections.Generic;
using System.Text;

namespace USAePayServiceLib.Customers
{
    class RetrieveCustomerListRequest : IRetrieveCustomerListRequest
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
