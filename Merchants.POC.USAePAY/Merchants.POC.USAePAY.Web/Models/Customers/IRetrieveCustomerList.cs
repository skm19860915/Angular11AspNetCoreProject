using Newtonsoft.Json;

namespace Merchants.POC.USAePAY.Web.Models.Customers
{
    interface IRetrieveCustomerList
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("customerid")]
        public string CustomerId { get; set; }
        [JsonProperty("custid")]
        public string CustId { get; set; }
        [JsonProperty("company")]
        public string Company { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("street2")]
        public string Street2 { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("postalcode")]
        public int PostalCode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("fax")]
        public string Fax { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("urls")]
        public string Url { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
