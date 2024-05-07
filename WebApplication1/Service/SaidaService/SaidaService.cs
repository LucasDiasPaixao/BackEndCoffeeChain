using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Service.SaidaService
{
    public class SaidaService : ISaidaInterface
    {
        public readonly CoffeeChainContext _context;
        public SaidaService(CoffeeChainContext context) 
        { 
            _context = context;
        }

        public async Task<ServiceResponse<List<Saida>>> CreateSaida(Saida novoSaida)
        {
            ServiceResponse<List<Saida>> serviceResponse = new ServiceResponse<List<Saida>>();

            try
            {
                if(novoSaida == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Preencher os dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoSaida);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Saidas.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso=false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Saida>>> DeleteSaida(int id)
        {
            ServiceResponse<List<Saida>> serviceResponse = new ServiceResponse<List<Saida>>();

            try
            {
                Saida Saida = _context.Saidas.FirstOrDefault(x => x.SaidaId == id);
                
                if (Saida == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Saida não localizado!";
                    serviceResponse.Sucesso = false;
                    
                    return serviceResponse;
                }

                _context.Saidas.Remove(Saida);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Saidas.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso=false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Saida>>> GetSaida()
        {
            ServiceResponse<List<Saida>> serviceResponse = new ServiceResponse<List<Saida>>();

            try
            {
                serviceResponse.Dados = _context.Saidas.ToList();

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

        public async Task<ServiceResponse<Saida>> GetSaidaById(int id)
        {
            ServiceResponse<Saida> serviceResponse = new ServiceResponse<Saida>();

            try
            {
                Saida Saida = _context.Saidas.FirstOrDefault(x => x.SaidaId == id);
                if(Saida == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Saida não localizado!";
                    serviceResponse.Sucesso=false;
                }

                serviceResponse.Dados = Saida;
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem=ex.Message;
                serviceResponse.Sucesso=false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Saida>>> UpdateSaida(Saida editaSaida)
        {
            ServiceResponse<List<Saida>> serviceResponse = new ServiceResponse<List<Saida>>();

            try
            {
                Saida Saida = _context.Saidas.AsNoTracking().FirstOrDefault(x => x.SaidaId == editaSaida.SaidaId);
                
                if (Saida == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Saida não localizado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Saidas.Update(editaSaida);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Saidas.ToList();
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
