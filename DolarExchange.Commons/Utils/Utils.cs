using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DolarExchange.Commons.Utils
{
    public static class Utils
    {
        public static string SendRequest(string user, string password, string url, string authorization)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if ((!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password)))
            {
                String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(user + ":" + password));
                request.Headers.Add("Authorization", "Basic " + encoded);
            }
            else if (!string.IsNullOrEmpty(authorization))
            {
                request.Headers.Add("Authorization", authorization);
            }
            String json = string.Empty;
            request.AutomaticDecompression = DecompressionMethods.GZip;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                }
            }
            catch (WebException we)
            {
                var dd = (we.Response as HttpWebResponse);
                if (dd.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    using (Stream stream = dd.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        json = reader.ReadToEnd();
                    }
                }
            }
            return json;
        }

    }
}
