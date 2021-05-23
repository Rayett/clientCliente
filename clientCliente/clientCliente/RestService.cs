using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace clientCliente
{
    static class RestService
    {
        static HttpClient client;
        static public string uri;

        public static void CreateUrl()        //https://8-1-2021-servicePorti.loca.lt
        {
            client = new HttpClient();
            string d = DateTime.Today.Day.ToString();
            string m = DateTime.Today.Month.ToString();
            string y = DateTime.Today.Year.ToString();
            uri = "https://" + d + "-" + m + "-" + y + "-servicePorti.loca.lt";
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("peinpeko", "1.0"));
            uri = "https://dangerous-shrimp-34.loca.lt";
            Console.WriteLine(uri);
        }

        public static async Task<string> get(string addURL) //GET
        {
            HttpResponseMessage response = null;
            String appUri = uri + addURL;
            try
            {
                Console.WriteLine("\n\nhalp me = " + uri + "\n\n");
                response = await client.GetAsync(appUri).ConfigureAwait(false);
            }
            catch (Exception ex)
            {            
                Console.WriteLine("\tERROR {0}", ex.Message);
            }
            string test = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("success");
                return test;
            }
            Console.WriteLine("failed");
            return ("204");
        }



        public static async Task<string> post(string addURL, string body) //POST
        {
            HttpResponseMessage response = null;
            String appUri = uri + addURL;
            try
            {
                Console.WriteLine("\n\n pog " + body);
                StringContent content = new StringContent(body, Encoding.UTF8, "text/plain");
                string myContent = await content.ReadAsStringAsync();
                Console.WriteLine("\n\n pogger " + myContent);
                response = await client.PostAsync(appUri, content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\tERROR {0}", ex.Message);
            }
            string test = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return test;
            }
            return ("204");
        }
    }
}
