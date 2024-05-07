using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Service.PropriedadeService;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PropriedadeController : ControllerBase
    {
        private readonly IPropriedadeInterface _PropriedadeInterface;

        public PropriedadeController(IPropriedadeInterface PropriedadeInterface)
        {
            _PropriedadeInterface = PropriedadeInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Propriedade>>>> GetPropriedade()
        {
            return Ok(await _PropriedadeInterface.GetPropriedade());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Propriedade>> GetPropriedadeById(int id)
        {
            ServiceResponse<Propriedade> serviceResponse = await _PropriedadeInterface.GetPropriedadeById(id);
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Propriedade>>>> CreatePropriedade(Propriedade novoPropriedade)
        {
            return Ok(await _PropriedadeInterface.CreatePropriedade(novoPropriedade));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Propriedade>>>> UpdatePropriedade(Propriedade editaPropriedade)
        {
            ServiceResponse<List<Propriedade>> serviceResponse = await _PropriedadeInterface.UpdatePropriedade(editaPropriedade);
            return Ok(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Propriedade>>>> DeletePropriedade(int id)
        {
            ServiceResponse<List<Propriedade>> serviceResponse = await _PropriedadeInterface.DeletePropriedade(id);

            return Ok(serviceResponse);
        }

    }
}
