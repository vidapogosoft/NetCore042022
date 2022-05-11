using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace DemoWinForm1.ApiHelper
{
    public class Consumer
    {

        private static HttpMethod CreateHtttpMethod(methodHttp method)
        {
            switch(method)
            {
                case methodHttp.GET:
                    return HttpMethod.Get;
                case methodHttp.POST:
                    return HttpMethod.Post;
                case methodHttp.PUT:
                    return HttpMethod.Put;
                case methodHttp.DELETE:
                    return HttpMethod.Delete;
                default:
                    throw new NotImplementedException("HTTP No Implementado");
            }
        }

        public static async Task<Reply> Execute<T>(string url, methodHttp method, T objectRequest)
        {
            Reply oreply = new Reply();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    var myContent = JsonConvert.SerializeObject(objectRequest);
                    var bytecontent = new ByteArrayContent(Encoding.UTF8.GetBytes(myContent));

                    var request = new HttpRequestMessage(CreateHtttpMethod(method), url)
                    {
                        Content = (method != methodHttp.GET) ? method != methodHttp.DELETE ? bytecontent : null : null
                    };

                    using (HttpResponseMessage res = await client.SendAsync(request))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            if(data != null)
                            {
                                oreply.Data = JsonConvert.DeserializeObject<T>(data);
                            }

                            oreply.StatusCode = res.StatusCode.ToString();
                        }
                    }

                }

            }
            catch (WebException ex)
            {
                oreply.StatusCode = "ServerError";
                var response = (HttpWebResponse)ex.Response;
                if (response != null)
                {
                    oreply.StatusCode = response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                oreply.StatusCode = "AppError: "  + ex.Message;
            }



            return oreply;
        }

    }
}
