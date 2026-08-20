using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.Service.ServicesHTTP
{
    public class HttpResponse<T>
    {
        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public HttpResponse(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }
        public string GetErrorMessage()
        {
            if(!Error)
            {
                return string.Empty;
            }
            else
            {
                var statusCode = HttpResponseMessage.StatusCode;

                switch(statusCode)
                {
                    case HttpStatusCode.NotFound:
                        return "Recurso no encontrado (404).";
                    case HttpStatusCode.BadRequest:
                        return "Solicitud incorrecta (400).";
                    case HttpStatusCode.Unauthorized:
                        return "No autenticado (401).";
                    case HttpStatusCode.Forbidden:
                        return "No autorizado (403).";
                    case HttpStatusCode.InternalServerError:
                        return "Error interno del servidor (500).";
                    case HttpStatusCode.NoContent:
                        return "No hay contenido (204).";
                    default:
                        return $"Error desconocido: {statusCode}";
                }
            }
        }
    }
}
