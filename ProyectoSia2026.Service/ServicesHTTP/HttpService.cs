using ProyectoSia2026.Service.ServicesHTTP;
using ProyectoSia2026.Service.ServiciosHTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProyectoSia2026.Service.ServicesHTTP
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient http;

        public HttpService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<HttpResponse<T>> Get<T>(string url)
        {
            var response = await http.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DesSerializar<T>(response);
                return new HttpResponse<T>(respuesta, false, response);
            }
            else
            {
                return new HttpResponse<T>(default, true, response);
            }
        }

        public async Task<HttpResponse<TResp>> Post<T, TResp>(string url, T entidad)
        {
             var JsonAEnviar = JsonSerializer.Serialize(entidad);
             var contenido = new StringContent(JsonAEnviar, 
                                               System.Text.Encoding.UTF8, "application/json");

             var response = await http.PostAsync(url, contenido);
             if (response.IsSuccessStatusCode)
             {
                 var respuesta = await DesSerializar<TResp>(response);
                 return new HttpResponse<TResp>(respuesta, false, response);
             }
             else
             {
                 return new HttpResponse<TResp>(default, true, response);
             }
        }

        private async Task<T?> DesSerializar<T>(HttpResponseMessage response)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>
                (responseString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}
