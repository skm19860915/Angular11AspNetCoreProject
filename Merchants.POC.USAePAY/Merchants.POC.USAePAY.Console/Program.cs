using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using USAePayServiceLib;

namespace Merchants.POC.USAePAY.Console
{
    class Program
    {
        private static string apiKey = "_X3C6h2LYWIP3642nsSLZ1elPC6i8ZXi";
        private static string apiPin = "19752021";

        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
            try
            {
                //_ = CreateCustomerProfile().Result;                
                //_ = CreatePaymentMethod("dsds9jy4vgyj7jts").Result;
                //_ = ChargeCustomerProfile("dsds9jy4vgyj7jts", "3n02p9swkhkjfn2gb").Result;
                _= GetCustomerList().Result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private static async Task<bool> GetCustomerList()
        {
            IDictionary<string, object> request = new Dictionary<string, object>();
            request["limit"] = "20";
            request["offset"] = "0";

            var paymentServiceContext = new PaymentServiceContext(apiKey, apiPin);
            var response = await paymentServiceContext.RetrieveCustomerList(request);
            var responseString = JsonConvert.SerializeObject(response);

            System.Diagnostics.Debug.WriteLine(responseString);

            return true;
        }

        private static async Task<bool> CreateCustomerProfile()
        {
            var paymentServiceContext = new PaymentServiceContext(apiKey, apiPin);
            await paymentServiceContext.CreateCustomer();
            
            return true;
        }

        private static async Task<bool> CreatePaymentMethod(string customerKey)
        {
            var paymentServiceContext = new PaymentServiceContext(apiKey, apiPin);
            await paymentServiceContext.CreatePaymentMethod(customerKey);

            return true;
        }

        private static async Task<bool> ChargeCustomerProfile(string customerKey, string paymentMethodKey)
        {
            var paymentServiceContext = new PaymentServiceContext(apiKey, apiPin);
            await paymentServiceContext.ChargeCustomer(customerKey, paymentMethodKey);

            return true;
        }
    }
}
