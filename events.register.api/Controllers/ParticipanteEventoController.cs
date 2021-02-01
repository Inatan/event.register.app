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

        private static List<ParticipanteEvento> _memoryParticipante = new List<ParticipanteEvento>();

        public ParticipanteEventoController(ILogger<ParticipanteEventoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca participantes do evento")]
        public ActionResult GetParticiante()
        {
            _logger.LogInformation($"Consulta realizada no server");
            return Ok(_memoryParticipante);
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
                if(_memoryParticipante.FindAll(p => p.Cpf == participante.Cpf).Count > 0)
                {
                    ModelState.AddModelError("Duplicado", "Esse participante já foi cadastrado");
                    _logger.LogError($"Erro no envio do cadastro: Esse participante já foi cadastrado");
                    return BadRequest(ErrorResponse.FromModelState(ModelState));
                }
                else
                {
                    _memoryParticipante.Add(participante);
                    _logger.LogInformation($"Cadastro de {participante.Nome} realizado com sucesso!");
                    return Created("", participante); // 201
                }
            }
            _logger.LogError($"Erro no envio do cadastro: {ErrorResponse.FromModelState(ModelState)}");
            return BadRequest(ErrorResponse.FromModelState(ModelState));
        }
    }
}
