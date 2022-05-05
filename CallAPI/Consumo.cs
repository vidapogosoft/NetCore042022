using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using Newtonsoft.Json;
using CallAPI.Model;
using System.Net.Http.Headers;

namespace CallAPI
{
    public class Consumo
    {
        public List<DTOPersona> ListPersona;
        public string Token = string.Empty;

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
                    //Metodos con seguridad del JWT
                    PostTokenApi();

                    if (!string.IsNullOrEmpty(Token))
                    {
                        GetApiAuth();
                    }
                        //Metodos sin seguridad del JWT
                        //GetApi1();
                        //PostApi1();


                        System.Threading.Thread.Sleep(5000);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        public async void GetApiAuth()
        {
            var uriget = new Uri("http://localhost:64508/api/PersonaGet/PerosnasAll1");

            if (string.IsNullOrEmpty(Token))
            {
                Console.WriteLine("No existe token");
            }
            else
            {
                //Especifico TOKEN JWT
                _Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                
                var responseget = await _Client.GetAsync(uriget);

                if (responseget.IsSuccessStatusCode)
                {
                    var contentget = await responseget.Content.ReadAsStringAsync();

                    ListPersona = JsonConvert.DeserializeObject<List<DTOPersona>>(contentget);

                }

                if (ListPersona.Count > 0)
                {
                    Console.WriteLine("get Exitoso: " + ListPersona.Count.ToString());
                }

            }


        }

        public async void PostTokenApi()
        {
            var uri = new Uri("http://localhost:64508/api/token/authenticate");

            TokenAuth auth = new TokenAuth();
            auth.Username = "demo";
            auth.Password = "123456";

            var json = JsonConvert.SerializeObject(auth);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage ResponseToken = null;

            ResponseToken = await _Client.PostAsync(uri, content);

            if (ResponseToken.IsSuccessStatusCode)
            {
                Token = ResponseToken.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                Console.WriteLine(Token);
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
