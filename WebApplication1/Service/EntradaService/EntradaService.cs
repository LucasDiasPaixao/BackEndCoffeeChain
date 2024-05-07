using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Service.EntradaService
{
    public class EntradaService : IEntradaInterface
    {
        public readonly CoffeeChainContext _context;
        public EntradaService(CoffeeChainContext context) 
        { 
            _context = context;
        }

        public async Task<ServiceResponse<List<Entrada>>> CreateEntrada(Entrada novoEntrada)
        {
            ServiceResponse<List<Entrada>> serviceResponse = new ServiceResponse<List<Entrada>>();

            try
            {
                if(novoEntrada == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Preencher os dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoEntrada);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Entradas.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso=false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Entrada>>> DeleteEntrada(int id)
        {
            ServiceResponse<List<Entrada>> serviceResponse = new ServiceResponse<List<Entrada>>();

            try
            {
                Entrada Entrada = _context.Entradas.FirstOrDefault(x => x.EntradaId == id);
                
                if (Entrada == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Entrada não localizado!";
                    serviceResponse.Sucesso = false;
                    
                    return serviceResponse;
                }

                _context.Entradas.Remove(Entrada);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Entradas.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso=false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Entrada>>> GetEntrada()
        {
            ServiceResponse<List<Entrada>> serviceResponse = new ServiceResponse<List<Entrada>>();

            try
            {
                serviceResponse.Dados = _context.Entradas.Include(x => x.Saida).ToList();

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

        public async Task<ServiceResponse<Entrada>> GetEntradaById(int id)
        {
            ServiceResponse<Entrada> serviceResponse = new ServiceResponse<Entrada>();

            try
            {
                Entrada Entrada = _context.Entradas.Include(x => x.Saida).FirstOrDefault(x => x.EntradaId == id);
                if(Entrada == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Entrada não localizado!";
                    serviceResponse.Sucesso=false;
                }

                serviceResponse.Dados = Entrada;
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem=ex.Message;
                serviceResponse.Sucesso=false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Entrada>>> UpdateEntrada(Entrada editaEntrada)
        {
            ServiceResponse<List<Entrada>> serviceResponse = new ServiceResponse<List<Entrada>>();

            try
            {
                Entrada Entrada = _context.Entradas.AsNoTracking().FirstOrDefault(x => x.EntradaId == editaEntrada.EntradaId);
                
                if (Entrada == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Entrada não localizado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Entradas.Update(editaEntrada);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Entradas.ToList();
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
