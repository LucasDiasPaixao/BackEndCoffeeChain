using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Service.ProdutorService;

namespace WebApplication1.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class ProdutoresController : ControllerBase
    {
        private readonly IProdutorInterface _produtorInterface;

        public ProdutoresController(IProdutorInterface produtorInterface)
        {
            _produtorInterface = produtorInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Produtores>>>> GetProdutor()
        {
            return Ok(await _produtorInterface.GetProdutor());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Produtores>> GetProdutorById(int id)
        {
            ServiceResponse<Produtores> serviceResponse = await _produtorInterface.GetProdutorById(id);
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Produtores>>>> CreateProdutor(Produtores novoProdutor)
        {
            return Ok(await _produtorInterface.CreateProdutor(novoProdutor));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Produtores>>>> UpdateProdutor(Produtores editaProdutor)
        {
            ServiceResponse<List<Produtores>> serviceResponse = await _produtorInterface.UpdateProdutor(editaProdutor);
            return Ok(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Produtores>>>> DeleteProdutor(int id)
        {
            ServiceResponse<List<Produtores>> serviceResponse = await _produtorInterface.DeleteProdutor(id);

            return Ok(serviceResponse);
        }

    }
}
