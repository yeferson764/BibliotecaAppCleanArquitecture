using AutoMapper;
using BibliotecaApp.Application.DTOs;
using BibliotecaApp.Application.Interfaces;
using BibliotecaApp.Domain.Interfaces.Repositories;

namespace BibliotecaApp.Application.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _repository;
        private readonly IMapper _mapper;

        public MaterialService(IMaterialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialDto>> GetAllAsync()
        {
            var materiales = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<MaterialDto>>(materiales);
        }

        public async Task<MaterialDto?> GetByIdAsync(int id)
        {
            var material = await _repository.GetByIdAsync(id);
            return material == null ? null : _mapper.Map<MaterialDto>(material);
        }

        public async Task AddAsync(MaterialDto dto)
        {
            var material = _mapper.Map<Material>(dto);
            material.FechaRegistro = DateTime.Now;
            material.CantidadActual = material.CantidadRegistrada;
            await _repository.AddAsync(material);
        }

        public async Task UpdateAsync(int id, MaterialDto dto)
        {
            var material = await _repository.GetByIdAsync(id);
            if (material == null) throw new Exception("Material no encontrado");
            material.Titulo = dto.Titulo;
            material.TipoId = dto.TipoId;
            _repository.Update(material);
        }

        public async Task DeleteAsync(int id)
        {
            var material = await _repository.GetByIdAsync(id);
            if (material == null) throw new Exception("Material no encontrado");
            _repository.Delete(material);
        }

        public async Task AddStockAsync(int id, int cantidad)
        {
            var material = await _repository.GetByIdAsync(id);
            if (material == null) throw new Exception("Material no encontrado");
            material.CantidadRegistrada += cantidad;
            material.CantidadActual += cantidad;
            _repository.Update(material);
        }
    }
}
