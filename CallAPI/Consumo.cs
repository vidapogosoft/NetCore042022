using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using Newtonsoft.Json;
using CallAPI.Model;

namespace CallAPI
{
    public class Consumo
    {
        public List<DTOPersona> ListPersona;

        HttpClient _Client;

        public Consumo()
        {
            _Client = new HttpClient();
        }

        public void ConsumoAPi()
        {
            while (true)
            {
                try
                {

                    GetApi1();
                    PostApi1();


                    System.Threading.Thread.Sleep(5000);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        public async void GetApi1()
        {
            var uriget = new Uri("http://localhost:5000/api/PersonaGet/PerosnasAll1");

            var responget = await _Client.GetAsync(uriget);

            if (responget.IsSuccessStatusCode)
            {
                var contentget = await responget.Content.ReadAsStringAsync();

                ListPersona = JsonConvert.DeserializeObject<List<DTOPersona>>(contentget);

            }

            if (ListPersona.Count > 0)
            {
                Console.WriteLine("get Exitoso: " + ListPersona.Count.ToString());
            }

        }

        public async void PostApi1()
        {
            var uripost = new Uri("http://localhost:5000/api/PersonaGet");

            DTOPersona item = new DTOPersona();

            item.Identificacion = "0919172551";
            item.Nombres = "Victor";
            item.Apellidos = "Portugal" + "-" + DateTime.Now.Ticks.ToString();

            var json = JsonConvert.SerializeObject(item);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage Response = null;

            Response = await _Client.PostAsync(uripost, content);

            if (Response.IsSuccessStatusCode)
            {
                Console.WriteLine("Post Exitoso: " + json.ToString());
            }

        }

    }
}
