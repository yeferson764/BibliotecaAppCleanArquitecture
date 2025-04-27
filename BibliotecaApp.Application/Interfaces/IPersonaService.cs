using BibliotecaApp.Application.DTOs.PersonasDtos;

namespace BibliotecaApp.Application.Interfaces
{
    public interface IPersonaService
    {
        Task<IEnumerable<PersonaDto>> GetAllAsync();
        Task<PersonaDto?> GetByIdAsync(int id);
        Task<PersonaDto?> GetByCedulaAsync(string cedula);
        Task AddAsync(PersonaCreateDto dto);
        Task UpdateAsync(int id, PersonaUpdateDto dto);
        Task DeleteAsync(int id);
        Task<int> GetDisponibilidadPrestamoAsync(int personaId);
    }
}
