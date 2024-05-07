using WebApplication1.Models;

namespace WebApplication1.Service.SaidaService
{
    public interface ISaidaInterface
    {
        Task<ServiceResponse<List<Saida>>> GetSaida();
        Task<ServiceResponse<List<Saida>>> CreateSaida(Saida novoSaida);
        Task<ServiceResponse<Saida>> GetSaidaById(int id);
        Task<ServiceResponse<List<Saida>>> UpdateSaida(Saida editaSaida);
        Task<ServiceResponse<List<Saida>>> DeleteSaida(int id);
    }
}
