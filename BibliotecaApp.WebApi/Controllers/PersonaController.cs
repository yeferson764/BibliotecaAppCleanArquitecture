using BibliotecaApp.Application.DTOs;
using BibliotecaApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _service;

        public PersonaController(IPersonaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var persona = await _service.GetByIdAsync(id);
            return persona == null ? NotFound() : Ok(persona);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonaDto dto)
        {
            await _service.AddAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PersonaDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("disponibilidad/{id}")]
        public async Task<IActionResult> Disponibilidad(int id)
        {
            var cantidad = await _service.GetDisponibilidadPrestamoAsync(id);
            return Ok(new { Disponibles = cantidad });
        }
    }
}
