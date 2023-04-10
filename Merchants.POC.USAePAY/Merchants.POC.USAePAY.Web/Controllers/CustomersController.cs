using Merchants.POC.USAePAY.Web.Models.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using USAePayServiceLib;

namespace Merchants.POC.USAePAY.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private PaymentServiceContext _context;

        public CustomersController(IConfiguration configuration)
        {
            _configuration = configuration;
            var apiKey = _configuration.GetSection("USAePaySettings").GetSection("ApiKey").Value;
            var apiPin = _configuration.GetSection("USAePaySettings").GetSection("ApiPin").Value;
            _context = new PaymentServiceContext(apiKey, apiPin);
        }

        [HttpGet]
        public async Task<IList<RetrieveCustomerListViewModel>> RetrieveCustomerList()
        {
            var record = new RetrieveCustomerListRequest()
            {
                Limit = 10,
                Offset = 0
            };

            IDictionary<string, object> request = new Dictionary<string, object>();
            request["limit"] = record.Limit;
            request["offset"] = record.Offset;

            var response = await _context.RetrieveCustomerList(request);
            if (response == null || response.Count < 1)
                return null;

            var result = JsonConvert.DeserializeObject<IList<RetrieveCustomerListViewModel>>(response["data"].ToString());
            if (result == null || result.Count < 1)
                return null;
            
            return result;
        }
    }
}
