using AutoMapper;
using BibliotecaApp.Application.DTOs;
using BibliotecaApp.Application.Interfaces;
using BibliotecaApp.Domain.Interfaces.Repositories;

namespace BibliotecaApp.Application.Services
{
    public class PrestamoService : IPrestamoService
    {
        private readonly IPrestamoRepository _prestamoRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;

        public PrestamoService(
            IPrestamoRepository prestamoRepository,
            IMaterialRepository materialRepository,
            IPersonaRepository personaRepository,
            IMapper mapper)
        {
            _prestamoRepository = prestamoRepository;
            _materialRepository = materialRepository;
            _personaRepository = personaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PrestamoDto>> GetAllAsync()
        {
            var prestamos = await _prestamoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PrestamoDto>>(prestamos);
        }

        public async Task<IEnumerable<PrestamoDto>> GetActivosAsync()
        {
            var prestamos = await _prestamoRepository.GetPrestamosActivosAsync();
            return _mapper.Map<IEnumerable<PrestamoDto>>(prestamos);
        }

        public async Task<IEnumerable<PrestamoDto>> GetDevueltosAsync()
        {
            var prestamos = await _prestamoRepository.GetPrestamosDevueltosAsync();
            return _mapper.Map<IEnumerable<PrestamoDto>>(prestamos);
        }

        public async Task<IEnumerable<PrestamoDto>> GetByPersonaAsync(int personaId)
        {
            var prestamos = await _prestamoRepository.GetPrestamosActivosPorPersonaAsync(personaId);
            return _mapper.Map<IEnumerable<PrestamoDto>>(prestamos);
        }

        public async Task<PrestamoDto?> GetByIdAsync(int id)
        {
            var prestamo = await _prestamoRepository.GetByIdAsync(id);
            return prestamo == null ? null : _mapper.Map<PrestamoDto>(prestamo);
        }

        public async Task GenerarPrestamoAsync(int personaId, int materialId)
        {
            var persona = await _personaRepository.GetByIdAsync(personaId);
            if (persona == null)
                throw new Exception("La persona no está registrada.");

            var material = await _materialRepository.GetByIdAsync(materialId);
            if (material == null)
                throw new Exception("El material no está registrado.");

            if (material.CantidadActual <= 0)
                throw new Exception("No hay stock disponible para este material.");

            var prestamosActivos = await _prestamoRepository.GetPrestamosActivosPorPersonaAsync(personaId);
            if (prestamosActivos.Count() >= persona.Rol.CapacidadPrestamo)
                throw new Exception("La persona alcanzó el límite de préstamos permitido.");

            var prestamo = new Prestamo
            {
                PersonaId = personaId,
                MaterialId = materialId,
                FechaPrestamo = DateTime.Now,
                Devuelto = false
            };

            material.CantidadActual--;
            _materialRepository.Update(material);
            await _prestamoRepository.AddAsync(prestamo);
        }

        public async Task RegistrarDevolucionAsync(int prestamoId)
        {
            var prestamo = await _prestamoRepository.GetByIdAsync(prestamoId);
            if (prestamo == null) throw new Exception("El préstamo no existe.");

            if (prestamo.Devuelto)
                throw new Exception("El material ya fue devuelto anteriormente.");

            var material = await _materialRepository.GetByIdAsync(prestamo.MaterialId);
            if (material == null) throw new Exception("El material asociado no fue encontrado.");

            prestamo.Devuelto = true;
            prestamo.FechaDevolucion = DateTime.Now;
            _prestamoRepository.Update(prestamo);

            material.CantidadActual++;
            _materialRepository.Update(material);
        }
    }
}
