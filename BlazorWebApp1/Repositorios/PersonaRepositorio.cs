using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using System.Net.Http;
using System.Text;
using System.Text.Json;


namespace BlazorWebApp1.Repositorios
{
    public class PersonaRepositorio: IPersonaRepositorio
    {

        private readonly HttpClient httpClient;

        private JsonSerializerOptions OpcionesPorDefectoJSON => new JsonSerializerOptions()
        { PropertyNameCaseInsensitive = true };

        public PersonaRepositorio (HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Consulta de datos desde el api
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<HttpResponseWrapper<T>> GetRegistrados<T>(string url)
        {
            var responseHTTP = await httpClient.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await DeserializarRespuesta<T>(responseHTTP, OpcionesPorDefectoJSON);

                return new HttpResponseWrapper<T>(response, false, responseHTTP);

            }
            else
            {
                return new HttpResponseWrapper<T>(default, true, responseHTTP);
            }
        }


        public async Task<HttpResponseWrapper<object>> PostRegistrado<T>(string url, T enviar)
        {
            var enviarJson = JsonSerializer.Serialize(enviar);

            var enviarContent = new StringContent(enviarJson, Encoding.UTF8, "application/json");

            var responseHTTP = await httpClient.PostAsync(url, enviarContent);

            return new HttpResponseWrapper<object>(null, !responseHTTP.IsSuccessStatusCode, responseHTTP);

        }

        public async Task<HttpResponseWrapper<object>> DeleteRegistrado(string url)
        {
            var responseHTTP = await httpClient.DeleteAsync(url);
            return new HttpResponseWrapper<object>(null, !responseHTTP.IsSuccessStatusCode, responseHTTP);
        }

        private async Task<T> DeserializarRespuesta<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);
        }


    }
}
