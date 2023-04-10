using Merchants.POC.USAePAY.Web.Models.CreateCreditCard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using USAePayServiceLib;

namespace Merchants.POC.USAePAY.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private PaymentServiceContext _context;
        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
            var apiKey = _configuration.GetSection("USAePaySettings").GetSection("ApiKey").Value;
            var apiPin = _configuration.GetSection("USAePaySettings").GetSection("ApiPin").Value;
            _context = new PaymentServiceContext(apiKey, apiPin);
        }

        [HttpGet]
        public async Task<List<CreateCreditCardResponse>> Index()
        {
            var customerKey = _configuration.GetSection("USAePaySettings").GetSection("CustomerKey").Value;
            var result = _context.CreateCreditCardMethod(customerKey).Result;
            var list = new List<CreateCreditCardResponse>();

            foreach (IDictionary<string, object> item in result)
            {
                var record = new CreateCreditCardResponse()
                {
                    Key = item["key"].ToString(),
                    Type = item["type"].ToString(),
                    MethodName = item["method_name"].ToString(),
                    Expires = item["expires"].ToString(),
                    CardType = item["card_type"].ToString(),
                    CcNum4Last = item["ccnum4last"].ToString(),
                    AvsStreet = item["avs_street"].ToString(),
                    AvsPostalCode = item["avs_postalcode"].ToString(),
                    SortOrd = item["sortord"].ToString(),
                    Added = item["added"].ToString(),
                    Updated = item["updated"].ToString()
                };
                list.Add(record);
            }
            return list;
        }
    }
}
