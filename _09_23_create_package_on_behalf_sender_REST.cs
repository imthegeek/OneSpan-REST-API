using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace FeatureGuideCharp
{
    class _09_23_create_package_on_behalf_sender_REST
    {
        public  void Execute()
        {
            var apiKey = "your_api_key";
            var apiUrl = "https://sandbox.esignlive.com/api";


            //create a package on behalf of a sender
            StringBuilder sb = new StringBuilder(200);
            sb.AppendLine("{                                                                                               ");
            sb.AppendLine("    \"status\": \"DRAFT\",                                                                      ");
            sb.AppendLine("    \"description\": \"A test transaction for 'sender on behalf of sender'\",                   ");
            sb.AppendLine("    \"language\": \"en\",                                                                       ");
            sb.AppendLine("    \"type\": \"PACKAGE\",                                                                     ");
            sb.AppendLine("    \"name\": \"Sender On Behalf Of Sender2\",                                                   ");
            sb.AppendLine("    \"sender\": {                                                                               ");
            sb.AppendLine("    \"email\": \"shrutimukherjee2020@gmail.com\"                                                       ");
            sb.AppendLine("    }                                                                                           ");
            sb.AppendLine("}                                                                                               ");


            string jsonString = sb.ToString();
            Debug.WriteLine(jsonString);
            StringContent jsonContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpClient myClient = new HttpClient();
            myClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", apiKey);
            myClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var result = myClient.PostAsync(new Uri(apiUrl) + "/packages/", jsonContent).Result;
            JObject returnJSON = JObject.Parse(result.Content.ReadAsStringAsync().Result);
            string packageId = returnJSON["id"].ToString();

            Debug.WriteLine("create a package on behalf of a sender: " + packageId);



            //create a template on behalf of a sender
            StringBuilder sb2 = new StringBuilder(200);
            sb2.AppendLine("{                                                                                               ");
            sb2.AppendLine("    \"status\": \"DRAFT\",                                                                      ");
            sb2.AppendLine("    \"description\": \"A test transaction for 'sender on behalf of sender'\",                   ");
            sb2.AppendLine("    \"language\": \"en\",                                                                       ");
            sb2.AppendLine("    \"type\": \"TEMPLATE\",                                                                     ");
            sb2.AppendLine("    \"visibility\":\"ACCOUNT\",                                                                 ");
            sb2.AppendLine("    \"name\": \"Sender On Behalf Of Sender2\",                                                   ");
            sb2.AppendLine("    \"sender\": {                                                                               ");
            sb2.AppendLine("    \"email\": \"shrutimukherjee2020@gmail.com\"                                                       ");
            sb2.AppendLine("    }                                                                                           ");
            sb2.AppendLine("}                                                                                               ");


            string jsonString2 = sb2.ToString();
            Debug.WriteLine(jsonString2);
            StringContent jsonContent2 = new StringContent(jsonString2, Encoding.UTF8, "application/json");
            HttpClient myClient2 = new HttpClient();
            myClient2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", apiKey);
            myClient2.DefaultRequestHeaders.Add("Accept", "application/json");

            var result2 = myClient2.PostAsync(new Uri(apiUrl) + "/packages/", jsonContent2).Result;
            JObject returnJSON2 = JObject.Parse(result2.Content.ReadAsStringAsync().Result);
            string packageId2 = returnJSON2["id"].ToString();

            Debug.WriteLine("create a template on behalf of a sender: " + packageId2);
        }
    }
}
