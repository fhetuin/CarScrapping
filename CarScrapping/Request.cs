using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarScrapping
{
    public static class Request
    {

        public async static Task<string> GetResultRequest(string url, string bearerToken = "")
        {
            string result = string.Empty;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:73.0) Gecko/20100101 Firefox/73.0";

            // Add the Authorization header with the bearer token
            if(!string.IsNullOrEmpty(bearerToken))
            req.Headers.Add("Authorization", $"Bearer {bearerToken}");

            try
            {
                var res = await req.GetResponseAsync();
                using (var reader = new StreamReader(res.GetResponseStream()))
                    result = await reader.ReadToEndAsync();

                return result;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
