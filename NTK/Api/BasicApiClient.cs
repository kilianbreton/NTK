using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace NTK.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class BasicApiClient
    {
        private Uri address;
        private String key;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="key"></param>
        public BasicApiClient(String address, String key)
        {
            this.address = new Uri(address);
            this.key = key;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="key"></param>
        public BasicApiClient(Uri address, String key)
        {
            this.address = address;
            this.key = key;
        }

        /// <summary>
        /// 
        /// </summary>
        public async void test()
        {
            using (var httpClient = new HttpClient())
            {
                // Always catch network exceptions for async methods
                try
                {                
                    var get = await httpClient.GetAsync(this.address + "/shodan/protocols?key="+key);
                    var result = await get.Content.ReadAsStringAsync();
                    var obj = JObject.Parse(result);
                    foreach(JToken token in obj.Children())
                    {
                        readObject(token);
                    }
                    
              
                }
                catch (Exception ex)
                {
                    // Details in ex.Message and ex.HResult.
                }
            }
        }

        /// <summary>
        /// recursive reader
        /// </summary>
        /// <param name="obj"></param>
        private void readObject(JToken obj)
        {
            if (obj.HasValues)
            {
                foreach(var child in obj.Values())
                {
                    readObject(child);
                }
            }
            else
            {
                Console.WriteLine(obj + " - " + obj.Type.ToString());
            }

        }
    }
}
