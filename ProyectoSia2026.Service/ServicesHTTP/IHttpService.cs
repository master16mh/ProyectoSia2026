using ProyectoSia2026.Service.ServicesHTTP;

namespace ProyectoSia2026.Service.ServiciosHTTP
{
    public interface IHttpService
    {
        Task<HttpResponse<T>> Get<T>(string url);
        Task<HttpResponse<TResp>> Post<T, TResp>(string url, T entidad);
    }
}