using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Service.ArmazemService;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ArmazemController : ControllerBase
    {
        private readonly IArmazemInterface _ArmazemInterface;

        public ArmazemController(IArmazemInterface ArmazemInterface)
        {
            _ArmazemInterface = ArmazemInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Armazem>>>> GetArmazem()
        {
            return Ok(await _ArmazemInterface.GetArmazem());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Armazem>> GetArmazemById(int id)
        {
            ServiceResponse<Armazem> serviceResponse = await _ArmazemInterface.GetArmazemById(id);
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Armazem>>>> CreateArmazem(Armazem novoArmazem)
        {
            return Ok(await _ArmazemInterface.CreateArmazem(novoArmazem));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Armazem>>>> UpdateArmazem(Armazem editaArmazem)
        {
            ServiceResponse<List<Armazem>> serviceResponse = await _ArmazemInterface.UpdateArmazem(editaArmazem);
            return Ok(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Armazem>>>> DeleteArmazem(int id)
        {
            ServiceResponse<List<Armazem>> serviceResponse = await _ArmazemInterface.DeleteArmazem(id);

            return Ok(serviceResponse);
        }

    }
}
