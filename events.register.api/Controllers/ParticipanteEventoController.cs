using events.register.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace events.register.api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/V{version:apiVersion}/[controller]")] //api/V{version:apiVersion}/
    public class ParticipanteEventoController : ControllerBase
    {
        private readonly ILogger<ParticipanteEventoController> _logger;

        public ParticipanteEventoController(ILogger<ParticipanteEventoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetParticiante()
        {
            List<ParticipanteEvento> listaParticipantes = new List<ParticipanteEvento> { 
                new ParticipanteEvento { 
                    Cidade = "Porto Alegre", 
                    Cpf = "027.591.130-60", 
                    Email = "inatan_hertzog@hotmail.com", 
                    Nascimento = "05/07/1993",//new DateTime(1993, 7, 5), 
                    Nome = "Inata Lopes Hertzog" 
                }
            };

            return Ok(listaParticipantes);
        }

        [HttpPost]
        public async Task<IActionResult> PostParticiante(ParticipanteEvento participante)
        {
            if (ModelState.IsValid)
            {
                return Created("", participante); // 201
            }
            return BadRequest(ErrorResponse.FromModelState(ModelState));
        }
    }
}
