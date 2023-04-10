namespace Merchants.POC.USAePAY.Web.Models.Customers
{
    interface IRetrieveCustomerListRequest
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
