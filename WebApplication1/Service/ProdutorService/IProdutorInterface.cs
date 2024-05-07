using WebApplication1.Models;

namespace WebApplication1.Service.ProdutorService
{
    public interface IProdutorInterface
    {
        Task<ServiceResponse<List<Produtores>>> GetProdutor();
        Task<ServiceResponse<List<Produtores>>> CreateProdutor(Produtores novoProdutor);
        Task<ServiceResponse<Produtores>> GetProdutorById(int id);
        Task<ServiceResponse<List<Produtores>>> UpdateProdutor(Produtores editaProdutor);
        Task<ServiceResponse<List<Produtores>>> DeleteProdutor(int id);
    }
}
