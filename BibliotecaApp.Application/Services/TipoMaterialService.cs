using AutoMapper;
using BibliotecaApp.Application.DTOs;
using BibliotecaApp.Application.Interfaces;
using BibliotecaApp.Domain.Interfaces.Repositories;

namespace BibliotecaApp.Application.Services
{
    public class TipoMaterialService : ITipoMaterialService
    {
        private readonly ITipoMaterialRepository _repository;
        private readonly IMapper _mapper;

        public TipoMaterialService(ITipoMaterialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoMaterialDto>> GetAllAsync()
        {
            var tipos = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TipoMaterialDto>>(tipos);
        }

        public async Task<TipoMaterialDto?> GetByIdAsync(int id)
        {
            var tipo = await _repository.GetByIdAsync(id);
            return tipo == null ? null : _mapper.Map<TipoMaterialDto>(tipo);
        }

        public async Task AddAsync(TipoMaterialDto dto)
        {
            var entity = _mapper.Map<TipoMaterial>(dto);
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, TipoMaterialDto dto)
        {
            var tipo = await _repository.GetByIdAsync(id);
            if (tipo == null) throw new Exception("Tipo de material no encontrado.");
            tipo.Tipo = dto.Tipo;
            _repository.Update(tipo);
        }

        public async Task DeleteAsync(int id)
        {
            var tipo = await _repository.GetByIdAsync(id);
            if (tipo == null) throw new Exception("Tipo de material no encontrado.");
            _repository.Delete(tipo);
        }
    }
}
