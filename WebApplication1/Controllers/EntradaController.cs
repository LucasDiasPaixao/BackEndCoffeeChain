using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Service.EntradaService;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EntradaController : ControllerBase
    {
        private readonly IEntradaInterface _EntradaInterface;

        public EntradaController(IEntradaInterface EntradaInterface)
        {
            _EntradaInterface = EntradaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Entrada>>>> GetEntrada()
        {
            return Ok(await _EntradaInterface.GetEntrada());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Entrada>> GetEntradaById(int id)
        {
            ServiceResponse<Entrada> serviceResponse = await _EntradaInterface.GetEntradaById(id);
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Entrada>>>> CreateEntrada(Entrada novoEntrada)
        {
            return Ok(await _EntradaInterface.CreateEntrada(novoEntrada));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Entrada>>>> UpdateEntrada(Entrada editaEntrada)
        {
            ServiceResponse<List<Entrada>> serviceResponse = await _EntradaInterface.UpdateEntrada(editaEntrada);
            return Ok(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Entrada>>>> DeleteEntrada(int id)
        {
            ServiceResponse<List<Entrada>> serviceResponse = await _EntradaInterface.DeleteEntrada(id);

            return Ok(serviceResponse);
        }

    }
}
