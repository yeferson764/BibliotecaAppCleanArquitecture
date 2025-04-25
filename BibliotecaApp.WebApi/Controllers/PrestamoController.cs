using BibliotecaApp.Application.DTOs;
using BibliotecaApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoService _service;

        public PrestamoController(IPrestamoService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var prestamo = await _service.GetByIdAsync(id);
            return prestamo == null ? NotFound() : Ok(prestamo);
        }

        [HttpGet("historial-completo")]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("activos")]
        public async Task<IActionResult> GetActivos() => Ok(await _service.GetActivosAsync());

        [HttpGet("devueltos")]
        public async Task<IActionResult> GetDevueltos() => Ok(await _service.GetDevueltosAsync());

        [HttpGet("persona/{id}")]
        public async Task<IActionResult> GetByPersona(int id) =>
            Ok(await _service.GetByPersonaAsync(id));

        [HttpPost]
        public async Task<IActionResult> Prestar([FromQuery] int personaId, [FromQuery] int materialId)
        {
            await _service.GenerarPrestamoAsync(personaId, materialId);
            return Ok();
        }

        [HttpPost("devolucion")]
        public async Task<IActionResult> Devolver([FromQuery] int prestamoId)
        {
            await _service.RegistrarDevolucionAsync(prestamoId);
            return Ok();
        }
    }
}
