using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using WebApplication1.Models;

namespace WebApplication1.Service.PropriedadeService
{
    public class PropriedadeService : IPropriedadeInterface
    {
        public readonly CoffeeChainContext _context;
        public PropriedadeService(CoffeeChainContext context) 
        { 
            _context = context;
        }

        public async Task<ServiceResponse<List<Propriedade>>> CreatePropriedade(Propriedade novoPropriedade)
        {
            ServiceResponse<List<Propriedade>> serviceResponse = new ServiceResponse<List<Propriedade>>();

            try
            {
                if(novoPropriedade == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Preencher os dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoPropriedade);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Propriedades.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso=false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Propriedade>>> DeletePropriedade(int id)
        {
            ServiceResponse<List<Propriedade>> serviceResponse = new ServiceResponse<List<Propriedade>>();

            try
            {
                Propriedade Propriedade = _context.Propriedades.FirstOrDefault(x => x.PropriedadeId == id);
                
                if (Propriedade == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Propriedade não localizado!";
                    serviceResponse.Sucesso = false;
                    
                    return serviceResponse;
                }

                _context.Propriedades.Remove(Propriedade);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Propriedades.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso=false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Propriedade>>> GetPropriedade()
        {
            ServiceResponse<List<Propriedade>> serviceResponse = new ServiceResponse<List<Propriedade>>();

            try
            {
                serviceResponse.Dados = _context.Propriedades.Include(x => x.Saida).Include(x => x.Entrada).ToList();

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

        public async Task<ServiceResponse<Propriedade>> GetPropriedadeById(int id)
        {
            ServiceResponse<Propriedade> serviceResponse = new ServiceResponse<Propriedade>();

            try
            {
                Propriedade Propriedade = _context.Propriedades.Include(x => x.Saida).Include(x => x.Entrada).FirstOrDefault (x => x.PropriedadeId == id);
                if(Propriedade == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Propriedade não localizado!";
                    serviceResponse.Sucesso=false;
                }

                serviceResponse.Dados = Propriedade;

                Produtores produtor = serviceResponse.Dados.Produtor;
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem=ex.Message;
                serviceResponse.Sucesso=false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Propriedade>>> UpdatePropriedade(Propriedade editaPropriedade)
        {
            ServiceResponse<List<Propriedade>> serviceResponse = new ServiceResponse<List<Propriedade>>();

            try
            {
                Propriedade Propriedade = _context.Propriedades.AsNoTracking().FirstOrDefault(x => x.PropriedadeId == editaPropriedade.PropriedadeId);
                
                if (Propriedade == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Propriedade não localizado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Propriedades.Update(editaPropriedade);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Propriedades.ToList();
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
