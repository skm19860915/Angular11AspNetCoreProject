using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace USAePayServiceLib
{
    public class PaymentServiceContext
    {
        public PaymentServiceContext (string apiKey, string apiPin)
        {
            USAePay.API.SetAuthentication(apiKey, apiPin);
            USAePay.API.SetURL("https://sandbox.usaepay.com", "v2");
        }

        public async Task<IDictionary<string, object>> RetrieveCustomerList(IDictionary<string, object> request)
        {
            var response = await USAePay.API.Customers.GetAsync(request);
            return response;
        }

        public async Task<string> CreateCustomer()
        {
            IDictionary<string, object> request = new Dictionary<string, object>();
            request["company"] = "Company Men Inc";
            request["first_name"] = "Robert";
            request["last_name"] = "Durst";
            request["customerid"] = "234545";
            request["street"] = "1222 Verdugo Cir";
            request["street2"] = "#303";
            request["city"] = "Los Angeles";
            request["state"] = "CA";
            request["postalcode"] = "90038";
            request["country"] = "USA";
            request["phone"] = "8888888888";
            request["fax"] = "7777777777";
            request["email"] = "johndoe-x@spiderwan.com";
            request["url"] = "ipp.domusscs.com";
            request["notes"] = "Signed up during January 2018 Promotion";
            request["description"] = "Gold Level Customer";

            var response = await USAePay.API.Customers.PostAsync(request);

            var responseString = JsonConvert.SerializeObject(response);

            System.Diagnostics.Debug.WriteLine(responseString);

            return responseString;
        }

        public async Task<string> CreatePaymentMethod(string customerKey)
        {
            IDictionary<string, object> request = new Dictionary<string, object>();
            request["custkey"] = customerKey;
            
            IList<IDictionary<string, object>> requestList = new List<IDictionary<string, object>>();
            IDictionary<string, object> requestListItem = new Dictionary<string, object>();

            requestListItem["method_name"] = "My T Pay";
            requestListItem["cardholder"] = "Jim Doe";
            requestListItem["number"] = "4000100011112224";
            requestListItem["expiration"] = "0922";
            requestListItem["avs_street"] = "123 Grindy St";
            requestListItem["avs_postalcode"] = "86577";
            requestListItem["pay_type"] = "cc";
            requestListItem["default"] = "1";
            requestListItem["sortord"] = "1";
            ////requestListItem["default"] = true;
            ////requestListItem["sortord"] = 1;

            requestList.Add(requestListItem);
            
            request["CustomerPaymentMethodRequests"] = requestList;

            var response = await USAePay.API.Customers.Payment_methods.PostAsync(request);

            var responseString = JsonConvert.SerializeObject(response);

            System.Diagnostics.Debug.WriteLine(responseString);

            return responseString;
        }

        public async Task<string> ChargeCustomer(string customerKey, string paymentMethodKey)
        {
     
            IDictionary<string, object> request = new Dictionary<string, object>();
            request["command"] = "customer:sale";
            request["custkey"] = customerKey;
            request["paymethod_key"] = paymentMethodKey;
            request["invoice"] = "IPP" + DateTime.UtcNow.Ticks.ToString();
            request["ponum"] = "IPP" + DateTime.UtcNow.Ticks.ToString();
            request["description"] = "Wolfsbane Potion";
            request["amount"] = "2.00";

            var response = await USAePay.API.Transactions.PostAsync(request);

            var responseString = JsonConvert.SerializeObject(response);

            System.Diagnostics.Debug.WriteLine(responseString);

            return responseString;
        }


        public async Task<IList<IDictionary<string, object>>> CreateCreditCardMethod(string customerKey)
        {
            IDictionary<string, object> request = new Dictionary<string, object>();
            request["custkey"] = customerKey;

            IList<IDictionary<string, object>> requestList = new List<IDictionary<string, object>>();
            IDictionary<string, object> requestListItem = new Dictionary<string, object>();

            requestListItem["method_name"] = "My T Pay";
            requestListItem["cardholder"] = "Jim Doe";
            requestListItem["number"] = "4000100011112224";
            requestListItem["expiration"] = "0922";
            requestListItem["avs_street"] = "123 Grindy St";
            requestListItem["avs_postalcode"] = "86577";
            requestListItem["pay_type"] = "cc";
            requestListItem["default"] = "1";
            requestListItem["sortord"] = "1";

            requestList.Add(requestListItem);

            request["requestList"] = requestList;

            //var response = await USAePay.API.Customers.Payment_methods.PostAsync(request);
            //var responseString = JsonConvert.SerializeObject(response);
            //return responseString;

            IList<IDictionary<string, object>> response = new List<IDictionary<string, object>>();
            IDictionary<string, object> responseItem = new Dictionary<string, object>();
            responseItem["key"] = "ln02pc6vxy98c79cs";
            responseItem["type"] = "customerpaymentmethod";
            responseItem["method_name"] = "Hogwarts Card";
            responseItem["expires"] = "2022-09-30";
            responseItem["card_type"] = "V";
            responseItem["ccnum4last"] = "2224";
            responseItem["avs_street"] = "123 Grindy St";
            responseItem["avs_postalcode"] = "86577";
            responseItem["sortord"] = "1";
            responseItem["added"] = "2019-01-04 14:54:22";
            responseItem["updated"] = "2019-01-04 14:54:22";
            response.Add(responseItem);

            return response;
        }
    }
}
