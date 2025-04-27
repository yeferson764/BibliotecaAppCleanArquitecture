using AutoMapper;
using BibliotecaApp.Application.DTOs.PersonasDtos;
using BibliotecaApp.Application.Interfaces;
using BibliotecaApp.Domain.Interfaces.Repositories;

namespace BibliotecaApp.Application.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IPrestamoRepository _prestamoRepository;
        private readonly IMapper _mapper;

        public PersonaService(IPersonaRepository personaRepository, IPrestamoRepository prestamoRepository, IMapper mapper)
        {
            _personaRepository = personaRepository;
            _prestamoRepository = prestamoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonaDto>> GetAllAsync()
        {
            var personas = await _personaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PersonaDto>>(personas);
        }

        public async Task<PersonaDto?> GetByIdAsync(int id)
        {
            var persona = await _personaRepository.GetByIdAsync(id);
            return persona == null ? null : _mapper.Map<PersonaDto>(persona);
        }

        public async Task<PersonaDto?> GetByCedulaAsync(string cedula)
        {
            var persona = await _personaRepository.GetByCedulaAsync(cedula);
            return persona == null ? null : _mapper.Map<PersonaDto>(persona);
        }

        public async Task AddAsync(PersonaCreateDto dto)
        {
            var existe = await _personaRepository.GetByCedulaAsync(dto.Cedula);
            if (existe != null)
                throw new Exception("Ya existe una persona registrada con esa cédula.");

            var persona = new Persona
            {
                Nombre = dto.Nombre,
                Cedula = dto.Cedula,
                RolId = dto.RolId
            };

            await _personaRepository.AddAsync(persona);
        }

        public async Task UpdateAsync(int id, PersonaUpdateDto dto)
        {
            var persona = await _personaRepository.GetByIdAsync(id);
            if (persona == null) throw new Exception("Persona no encontrada.");

            _mapper.Map(dto, persona);

            await _personaRepository.UpdateAsync(persona);
        }


        public async Task DeleteAsync(int id)
        {
            var persona = await _personaRepository.GetByIdAsync(id);
            if (persona == null) throw new Exception("Persona no encontrada.");

            var prestamos = await _prestamoRepository.GetPrestamosActivosPorPersonaAsync(id);
            if (prestamos.Any())
                throw new Exception("No se puede eliminar una persona que tiene préstamos activos.");

            _personaRepository.Delete(persona);
        }

        public async Task<int> GetDisponibilidadPrestamoAsync(int personaId)
        {
            var persona = await _personaRepository.GetByIdAsync(personaId);
            if (persona == null) throw new Exception("Persona no encontrada.");

            var prestamosActivos = await _prestamoRepository.GetPrestamosActivosPorPersonaAsync(personaId);
            int usados = prestamosActivos.Count();
            int total = persona.Rol.CapacidadPrestamo;

            return total - usados;
        }
    }
}
