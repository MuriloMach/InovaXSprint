using InovaXSprint.Models;
using InovaXSprint.Repository; 
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace InovaXSprint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacoesController : ControllerBase
    {
        private readonly IRepository<Avaliacao> _repository;

        public AvaliacoesController(IRepository<Avaliacao> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] Avaliacao avaliacao)
        {
            _repository.Add(avaliacao);
            return CreatedAtAction(nameof(GetAll), new { id = avaliacao.IdAvaliacao }, avaliacao);
        }

        [HttpGet("v1/avaliacao")]
        [ProducesResponseType(typeof(List<Avaliacao>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            var avaliacoes = _repository.GetAll();
            return Ok(avaliacoes);
        }

        [HttpPatch("v1/avaliacao")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Patch([FromBody] Avaliacao avaliacao)
        {
            _repository.Update(avaliacao);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete([FromBody] Avaliacao avaliacao)
        {
            _repository.Delete(avaliacao);
            return Ok();
        }
    }
}