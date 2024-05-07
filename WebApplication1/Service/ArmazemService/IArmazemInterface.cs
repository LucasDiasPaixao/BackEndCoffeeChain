using WebApplication1.Models;

namespace WebApplication1.Service.ArmazemService
{
    public interface IArmazemInterface
    {
        Task<ServiceResponse<List<Armazem>>> GetArmazem();
        Task<ServiceResponse<List<Armazem>>> CreateArmazem(Armazem novoArmazem);
        Task<ServiceResponse<Armazem>> GetArmazemById(int id);
        Task<ServiceResponse<List<Armazem>>> UpdateArmazem(Armazem editaArmazem);
        Task<ServiceResponse<List<Armazem>>> DeleteArmazem(int id);
    }
}
