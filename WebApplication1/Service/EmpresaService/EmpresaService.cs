using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Service.EmpresaService
{
    public class EmpresaService : IEmpresaInterface
    {
        public readonly CoffeeChainContext _context;
        public EmpresaService(CoffeeChainContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Empresa>>> CreateEmpresa(Empresa novoEmpresa)
        {
            ServiceResponse<List<Empresa>> serviceResponse = new ServiceResponse<List<Empresa>>();

            try
            {
                if (novoEmpresa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Preencher os dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoEmpresa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Empresas.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Empresa>>> DeleteEmpresa(int id)
        {
            ServiceResponse<List<Empresa>> serviceResponse = new ServiceResponse<List<Empresa>>();

            try
            {
                Empresa Empresa = _context.Empresas.FirstOrDefault(x => x.EmpresaId == id);

                if (Empresa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Empresa não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Empresas.Remove(Empresa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Empresas.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Empresa>>> GetEmpresa()
        {
            ServiceResponse<List<Empresa>> serviceResponse = new ServiceResponse<List<Empresa>>();

            try
            {
                serviceResponse.Dados = _context.Empresas.Include(x => x.Armazem)
                                                         .Include(x => x.Saida)
                                                         .Include(x => x.Entrada)
                                                         .ToList();

                if (serviceResponse.Dados.Count == 0)
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

        public async Task<ServiceResponse<Empresa>> GetEmpresaById(int id)
        {
            ServiceResponse<Empresa> serviceResponse = new ServiceResponse<Empresa>();

            try
            {
                Empresa Empresa = _context.Empresas.Include(x => x.Armazem).FirstOrDefault(x => x.EmpresaId == id);
                if (Empresa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Empresa não localizado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = Empresa;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Empresa>>> UpdateEmpresa(Empresa editaEmpresa)
        {
            ServiceResponse<List<Empresa>> serviceResponse = new ServiceResponse<List<Empresa>>();

            try
            {
                Empresa Empresa = _context.Empresas.AsNoTracking().FirstOrDefault(x => x.EmpresaId == editaEmpresa.EmpresaId);

                if (Empresa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Empresa não localizado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Empresas.Update(editaEmpresa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Empresas.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
