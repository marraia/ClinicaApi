using System.Net;
using Clinica.API.Model;
using Clinica.Modelo;
using Clinica.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Clinica.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Paciente")]
    public class PacienteController : Controller
    {
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, typeof(Paciente), nameof(HttpStatusCode.OK))]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult Get()
        {
            var paciente = new RepositorioPaciente();
            var lista = paciente.ObterPacientes();

            return Ok(lista);
        }

        [HttpGet]
        [Route("{id}", Name = "GetId")] 
        [SwaggerResponse((int)HttpStatusCode.OK, typeof(Paciente), nameof(HttpStatusCode.OK))]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult Get(int id)
        {
            var repositorio = new RepositorioPaciente();
            var paciente = repositorio.ObterPaciente(id);

            return Ok(paciente);
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created, typeof(Paciente), nameof(HttpStatusCode.Created))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody]PacienteInput input)
        {
            var repositorio = new RepositorioPaciente();
            var paciente = repositorio.Inserir(input.Nome, input.Cpf, input.Historico);


            return CreatedAtRoute("GetId", new { id = paciente.Id }, paciente);
        }

        [HttpPut]
        [Route("{id}")]
        [SwaggerResponse((int)HttpStatusCode.Accepted, typeof(Paciente), nameof(HttpStatusCode.Accepted))]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public IActionResult Put(int id, [FromBody]PacienteInput input)
        {
            var repositorio = new RepositorioPaciente();
            repositorio.Atualizar(id, input.Nome, input.Cpf, input.Historico);


            return Accepted(input);
        }

        [HttpDelete]
        [Route("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, typeof(Paciente), nameof(HttpStatusCode.OK))]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult Delete(int id)
        {
            var repositorio = new RepositorioPaciente();
            repositorio.Excluir(id);


            return Ok();
        }
    }
}