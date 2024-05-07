using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Service.EmpresaService;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaInterface _EmpresaInterface;

        public EmpresaController(IEmpresaInterface EmpresaInterface)
        {
            _EmpresaInterface = EmpresaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Empresa>>>> GetEmpresa()
        {
            return Ok(await _EmpresaInterface.GetEmpresa());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Empresa>> GetEmpresaById(int id)
        {

            ServiceResponse<Empresa> serviceResponse = await _EmpresaInterface.GetEmpresaById(id);
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Empresa>>>> CreateEmpresa(Empresa novoEmpresa)
        {
            return Ok(await _EmpresaInterface.CreateEmpresa(novoEmpresa));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Empresa>>>> UpdateEmpresa(Empresa editaEmpresa)
        {
            ServiceResponse<List<Empresa>> serviceResponse = await _EmpresaInterface.UpdateEmpresa(editaEmpresa);
            return Ok(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Empresa>>>> DeleteEmpresa(int id)
        {
            ServiceResponse<List<Empresa>> serviceResponse = await _EmpresaInterface.DeleteEmpresa(id);

            return Ok(serviceResponse);
        }

    }
}
