using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ESender
{
    static class ManagerOfNetworking
    {
        public static String Get(String url, String data)
        {
            string text = "";

            WebRequest req = WebRequest.Create(url + "?" + data);
            WebResponse resp = req.GetResponse();

            using (Stream stream = resp.GetResponseStream())
            {
                if (stream != null) text = new StreamReader(stream).ReadToEnd();
            }

            return text;
        }

        public static String Post(String url, String data, String postData)
        {
            string result = "";

            WebRequest request = WebRequest.Create(url + "?" + data);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                if (stream != null)
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();
                    }
                }
            }

            return result;
        }
    }
}