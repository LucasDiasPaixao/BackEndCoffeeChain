using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using WebApplication1.Models;

namespace WebApplication1.Service.ProdutorService
{
    public class ProdutorService : IProdutorInterface
    {
        public readonly CoffeeChainContext _context;
        public ProdutorService(CoffeeChainContext context) 
        { 
            _context = context;
        }


        public async Task<ServiceResponse<List<Produtores>>> CreateProdutor(Produtores novoProdutor)
        {
            ServiceResponse<List<Produtores>> serviceResponse = new ServiceResponse<List<Produtores>>();

            try
            {
                if(novoProdutor == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Preencher os dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoProdutor);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Produtores.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso=false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Produtores>>> DeleteProdutor(int id)
        {
            ServiceResponse<List<Produtores>> serviceResponse = new ServiceResponse<List<Produtores>>();

            try
            {
                Produtores produtor = _context.Produtores.FirstOrDefault(x => x.ProdutorId == id);
                
                if (produtor == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produtor não localizado!";
                    serviceResponse.Sucesso = false;
                    
                    return serviceResponse;
                }

                _context.Produtores.Remove(produtor);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Produtores.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso=false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Produtores>>> GetProdutor()
        {
            ServiceResponse<List<Produtores>> serviceResponse = new ServiceResponse<List<Produtores>>();

            try
            {
                serviceResponse.Dados = _context.Produtores.Include(x => x.Propriedades).Include(x => x.Saida).Include(x => x.Entrada).ToList();

                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Produtores>> GetProdutorById(int id)
        {
            ServiceResponse<Produtores> serviceResponse = new ServiceResponse<Produtores>();

            try
            {
                Produtores produtor = _context.Produtores.Include(x => x.Propriedades)
                                                         .Include(x => x.Saida)
                                                         .Include(x => x.Entrada)
                                                         .FirstOrDefault(x => x.ProdutorId == id);
                if(produtor == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produtor não localizado!";
                    serviceResponse.Sucesso=false;
                }

                serviceResponse.Dados = produtor;
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem=ex.Message;
                serviceResponse.Sucesso=false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Produtores>>> UpdateProdutor(Produtores editaProdutor)
        {
            ServiceResponse<List<Produtores>> serviceResponse = new ServiceResponse<List<Produtores>>();

            try
            {
                Produtores produtor = _context.Produtores.AsNoTracking().FirstOrDefault(x => x.ProdutorId == editaProdutor.ProdutorId);
                
                if (produtor == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produtor não localizado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Produtores.Update(editaProdutor);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Produtores.ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso=false;
            }
            return serviceResponse;
        }
    }
}
