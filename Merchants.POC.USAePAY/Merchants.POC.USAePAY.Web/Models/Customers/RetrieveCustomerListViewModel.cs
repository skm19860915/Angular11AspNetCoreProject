namespace Merchants.POC.USAePAY.Web.Models.Customers
{
    public class RetrieveCustomerListViewModel : IRetrieveCustomerList
    {
        public string Key { get; set; }
        public string Type { get; set; }
        public string CustomerId { get; set; }
        public string CustId { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string  State { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }
    }
}
