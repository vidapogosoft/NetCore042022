using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;


using WebForm1.Helper;
using WebForm1.DTO;
using System.Text;

namespace WebForm1.Services
{
    public class RestServicesPersona
    {
        public List<DTOPersona> ListPersonas;

        HttpClient _client;

        public RestServicesPersona()
        {
            _client = new HttpClient();
        }

        public async Task<List<DTOPersona>> GetPersonas()
        {
            ListPersonas = new List<DTOPersona>();

            var uri = new Uri(string.Format(RootApi.ItemsUrl, "PersonaGet/PersonasAll1", string.Empty));

            try
            {
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    ListPersonas = JsonConvert.DeserializeObject<List<DTOPersona>>(content);

                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Error {0}", ex.Message);
            }


            return ListPersonas;

        }

        public async Task<int> SaveDatos(DTOPersona item)
        {
            int Grabado = 0;

            var uri = new Uri(string.Format(RootApi.ItemsUrl, "PersonaGet", string.Empty));

            try
            {

                var json = JsonConvert.SerializeObject(item);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage Response = null;

                Response = await _client.PostAsync(uri, content);

                if (Response.IsSuccessStatusCode)
                {
                    Grabado = 1;
                    Console.WriteLine("Post Exitoso: " + json.ToString());
                }

                return Grabado;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Error {0}", ex.Message);
                return Grabado;
            }

        }
    }
}