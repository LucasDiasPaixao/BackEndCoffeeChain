using WebApplication1.Models;

namespace WebApplication1.Service.PropriedadeService
{
    public interface IPropriedadeInterface
    {
        Task<ServiceResponse<List<Propriedade>>> GetPropriedade();
        Task<ServiceResponse<List<Propriedade>>> CreatePropriedade(Propriedade novoPropriedade);
        Task<ServiceResponse<Propriedade>> GetPropriedadeById(int id);
        Task<ServiceResponse<List<Propriedade>>> UpdatePropriedade(Propriedade editaPropriedade);
        Task<ServiceResponse<List<Propriedade>>> DeletePropriedade(int id);
    }
}
