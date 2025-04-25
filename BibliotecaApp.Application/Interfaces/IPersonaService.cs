using BibliotecaApp.Application.DTOs;

namespace BibliotecaApp.Application.Interfaces
{
    public interface IPersonaService
    {
        Task<IEnumerable<PersonaDto>> GetAllAsync();
        Task<PersonaDto?> GetByIdAsync(int id);
        Task<PersonaDto?> GetByCedulaAsync(string cedula);
        Task AddAsync(PersonaDto dto);
        Task UpdateAsync(int id, PersonaDto dto);
        Task DeleteAsync(int id);
        Task<int> GetDisponibilidadPrestamoAsync(int personaId);
    }
}
