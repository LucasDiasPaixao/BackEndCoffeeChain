using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Service.SaidaService;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SaidaController : ControllerBase
    {
        private readonly ISaidaInterface _SaidaInterface;

        public SaidaController(ISaidaInterface SaidaInterface)
        {
            _SaidaInterface = SaidaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Saida>>>> GetSaida()
        {
            return Ok(await _SaidaInterface.GetSaida());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Saida>> GetSaidaById(int id)
        {
            ServiceResponse<Saida> serviceResponse = await _SaidaInterface.GetSaidaById(id);
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Saida>>>> CreateSaida(Saida novoSaida)
        {
            return Ok(await _SaidaInterface.CreateSaida(novoSaida));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Saida>>>> UpdateSaida(Saida editaSaida)
        {
            ServiceResponse<List<Saida>> serviceResponse = await _SaidaInterface.UpdateSaida(editaSaida);
            return Ok(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Saida>>>> DeleteSaida(int id)
        {
            ServiceResponse<List<Saida>> serviceResponse = await _SaidaInterface.DeleteSaida(id);

            return Ok(serviceResponse);
        }

    }
}
