using System;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Text.RegularExpressions;

namespace Re_useable_Classes.Windows
{
    public class GetIP
    {
        public static string GetClientIp()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            var endpoint =
                prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            return endpoint != null
                       ? endpoint.Address
                       : GetClientExternalIp();
        }

        private static string GetClientExternalIp()
        {
            const string ipUrl1 = "http://checkip.dyndns.org";
            const string ipUrl2 = "http://www.ipchicken.com/";
            const string ipUrl3 = "http://www.showmyip.com/";

            string ipaddress = (GetExternalIp(ipUrl1) ?? GetExternalIp(ipUrl2)) ?? GetExternalIp(ipUrl3);


            return ipaddress;
        }

        private static string GetExternalIp(string ipAddress)
        {
            string ipUrl = ipAddress;

            // Try to parse out the IP address from the returned HTML

            try
            {
                WebRequest objWebReq = WebRequest.Create(ipUrl);

                WebResponse objWebResp = objWebReq.GetResponse();

                Stream strmResp = objWebResp.GetResponseStream();

                if (strmResp != null)
                {
                    var srResp = new StreamReader
                        (
                        strmResp,
                        Encoding.UTF8);

                    string strHtml = srResp.ReadToEnd();
                    //Prepare Format to look for on the website' HTML
                    var regexIp = new Regex
                        (
                        @"\b\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}\b");

                    string strIp = regexIp.Match(strHtml)
                                          .Value;

                    return strIp;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Can't retrieve external IP: " + ex.Message);

                return null;
            }
            return null;
        }
    }
}
