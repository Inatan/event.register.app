using events.register.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace events.register.api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/V{version:apiVersion}/[controller]")]
    public class ParticipanteEventoController : ControllerBase
    {
        private readonly ILogger<ParticipanteEventoController> _logger;

        public ParticipanteEventoController(ILogger<ParticipanteEventoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca participantes do evento")]
        public ActionResult GetParticiante()
        {
            List<ParticipanteEvento> listaParticipantes = new List<ParticipanteEvento> { 
                new ParticipanteEvento { 
                    Cidade = "Porto Alegre", 
                    Cpf = "027.591.130-60", 
                    Email = "inatan_hertzog@hotmail.com", 
                    Nascimento = new DateTime(1993, 7, 5), 
                    Nome = "Inata Lopes Hertzog" 
                }
            };

            return Ok(listaParticipantes);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Registra o participante no evento")]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: 201, Type = typeof(ParticipanteEvento))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public IActionResult PostParticiante(ParticipanteEvento participante)
        {
            if (ModelState.IsValid)
            {
                return Created("", participante); // 201
            }
            return BadRequest(ErrorResponse.FromModelState(ModelState));
        }
    }
}
