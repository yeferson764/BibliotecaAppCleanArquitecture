using BibliotecaApp.Application.DTOs.MaterialDtos;
using BibliotecaApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _service;

        public MaterialController(IMaterialService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var material = await _service.GetByIdAsync(id);
            return material == null ? NotFound() : Ok(material);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MaterialCreateAndUpdateDto dto)
        {
            await _service.AddAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MaterialCreateAndUpdateDto dto)
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

        [HttpPut("{id}/enter-stock")]
        public async Task<IActionResult> AddStock(int id, [FromQuery] int cantidad)
        {
            await _service.AddStockAsync(id, cantidad);
            return Ok();
        }
    }
}
