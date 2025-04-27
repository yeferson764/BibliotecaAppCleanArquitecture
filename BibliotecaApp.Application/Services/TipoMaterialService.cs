using AutoMapper;
using BibliotecaApp.Application.DTOs.TipoMaterialDtos;
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

        public async Task AddAsync(TipoMaterialCreateAndUpdateDto dto)
        {
            var tipoMaterial = _mapper.Map<TipoMaterial>(dto);
            await _repository.AddAsync(tipoMaterial);
        }

        public async Task UpdateAsync(int id, TipoMaterialCreateAndUpdateDto dto)
        {
            var tipo = await _repository.GetByIdAsync(id);
            if (tipo == null) throw new Exception("Tipo de material no encontrado.");

            _mapper.Map(dto, tipo);

            await _repository.UpdateAsync(tipo);
        }

        public async Task DeleteAsync(int id)
        {
            var tipo = await _repository.GetByIdAsync(id);
            if (tipo == null) throw new Exception("Tipo de material no encontrado.");
            await _repository.DeleteAsync(tipo);
        }
    }
}
