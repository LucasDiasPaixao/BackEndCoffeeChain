using WebApplication1.Models;

namespace WebApplication1.Service.EntradaService
{
    public interface IEntradaInterface
    {
        Task<ServiceResponse<List<Entrada>>> GetEntrada();
        Task<ServiceResponse<List<Entrada>>> CreateEntrada(Entrada novoEntrada);
        Task<ServiceResponse<Entrada>> GetEntradaById(int id);
        Task<ServiceResponse<List<Entrada>>> UpdateEntrada(Entrada editaEntrada);
        Task<ServiceResponse<List<Entrada>>> DeleteEntrada(int id);
    }
}
