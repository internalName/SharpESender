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
    }
}