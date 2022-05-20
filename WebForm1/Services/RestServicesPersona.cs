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

            var uri = new Uri(string.Format(RootApi.ItemsUrl, "PersonaGet", string.Empty));

            try
            {
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync();

                    ListPersonas = JsonConvert.DeserializeObject<List<DTOPersona>>(content.ToString());

                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Error {0}", ex.Message);
            }


            return ListPersonas;

        }

    }
}