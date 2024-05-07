using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Service.ArmazemService
{
    public class ArmazemService : IArmazemInterface
    {
        public readonly CoffeeChainContext _context;
        public ArmazemService(CoffeeChainContext context) 
        { 
            _context = context;
        }

        public async Task<ServiceResponse<List<Armazem>>> CreateArmazem(Armazem novoArmazem)
        {
            ServiceResponse<List<Armazem>> serviceResponse = new ServiceResponse<List<Armazem>>();

            try
            {
                if(novoArmazem == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Preencher os dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoArmazem);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Armazens.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso=false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Armazem>>> DeleteArmazem(int id)
        {
            ServiceResponse<List<Armazem>> serviceResponse = new ServiceResponse<List<Armazem>>();

            try
            {
                Armazem Armazem = _context.Armazens.FirstOrDefault(x => x.ArmazemId == id);
                
                if (Armazem == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Armazem não localizado!";
                    serviceResponse.Sucesso = false;
                    
                    return serviceResponse;
                }

                _context.Armazens.Remove(Armazem);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Armazens.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso=false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Armazem>>> GetArmazem()
        {
            ServiceResponse<List<Armazem>> serviceResponse = new ServiceResponse<List<Armazem>>();

            try
            {
                serviceResponse.Dados = _context.Armazens.Include(x => x.Entrada).ToList();

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

        public async Task<ServiceResponse<Armazem>> GetArmazemById(int id)
        {
            ServiceResponse<Armazem> serviceResponse = new ServiceResponse<Armazem>();

            try
            {
                Armazem Armazem = _context.Armazens.Include(x => x.Entrada).FirstOrDefault(x => x.ArmazemId == id);
                if(Armazem == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Armazem não localizado!";
                    serviceResponse.Sucesso=false;
                }

                serviceResponse.Dados = Armazem;
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem=ex.Message;
                serviceResponse.Sucesso=false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Armazem>>> UpdateArmazem(Armazem editaArmazem)
        {
            ServiceResponse<List<Armazem>> serviceResponse = new ServiceResponse<List<Armazem>>();

            try
            {
                Armazem Armazem = _context.Armazens.AsNoTracking().FirstOrDefault(x => x.ArmazemId == editaArmazem.ArmazemId);
                
                if (Armazem == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Armazem não localizado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Armazens.Update(editaArmazem);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Armazens.ToList();
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
