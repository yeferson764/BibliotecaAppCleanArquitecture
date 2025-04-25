using AutoMapper;
using BibliotecaApp.Application.DTOs;
using BibliotecaApp.Application.Interfaces;
using BibliotecaApp.Domain.Interfaces.Repositories;

namespace BibliotecaApp.Application.Services
{    public class RolService : IRolService
    {
        private readonly IRolRepository _repository;
        private readonly IMapper _mapper;

        public RolService(IRolRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RolDto>> GetAllAsync()
        {
            var roles = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<RolDto>>(roles);
        }

        public async Task<RolDto?> GetByIdAsync(int id)
        {
            var rol = await _repository.GetByIdAsync(id);
            return rol == null ? null : _mapper.Map<RolDto>(rol);
        }

        public async Task AddAsync(RolDto dto)
        {
            var rol = _mapper.Map<Rol>(dto);
            await _repository.AddAsync(rol);
        }

        public async Task UpdateAsync(int id, RolDto dto)
        {
            var rol = await _repository.GetByIdAsync(id);
            if (rol == null) throw new Exception("Rol no encontrado.");
            rol.RolName = dto.RolName;
            rol.CapacidadPrestamo = dto.CapacidadPrestamo;
            await _repository.UpdateAsync(rol);
        }

        public async Task DeleteAsync(int id)
        {
            var rol = await _repository.GetByIdAsync(id);
            if (rol == null) throw new Exception("Rol no encontrado.");
            await _repository.DeleteAsync(rol);
        }
    }
}
