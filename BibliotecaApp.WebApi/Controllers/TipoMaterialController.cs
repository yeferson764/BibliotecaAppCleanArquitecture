using BibliotecaApp.Application.DTOs;
using BibliotecaApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoMaterialController : ControllerBase
    {
        private readonly ITipoMaterialService _service;

        public TipoMaterialController(ITipoMaterialService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tipo = await _service.GetByIdAsync(id);
            return tipo == null ? NotFound() : Ok(tipo);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TipoMaterialDto dto)
        {
            await _service.AddAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TipoMaterialDto dto)
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
    }
}
