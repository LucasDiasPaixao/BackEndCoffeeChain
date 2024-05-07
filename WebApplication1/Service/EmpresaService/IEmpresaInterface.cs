using WebApplication1.Models;

namespace WebApplication1.Service.EmpresaService
{
    public interface IEmpresaInterface
    {
        Task<ServiceResponse<List<Empresa>>> GetEmpresa();
        Task<ServiceResponse<List<Empresa>>> CreateEmpresa(Empresa novoEmpresa);
        Task<ServiceResponse<Empresa>> GetEmpresaById(int id);
        Task<ServiceResponse<List<Empresa>>> UpdateEmpresa(Empresa editaEmpresa);
        Task<ServiceResponse<List<Empresa>>> DeleteEmpresa(int id);
    }
}
