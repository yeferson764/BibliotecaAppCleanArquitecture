using BibliotecaApp.Application.DTOs.PersonasDtos;

namespace BibliotecaApp.Application.Interfaces
{
    public interface IPrestamoService
    {
        Task<IEnumerable<PrestamoDto>> GetAllAsync();
        Task<IEnumerable<PrestamoDto>> GetActivosAsync();
        Task<IEnumerable<PrestamoDto>> GetDevueltosAsync();
        Task<IEnumerable<PrestamoDto>> GetByPersonaAsync(int personaId);
        Task<PrestamoDto?> GetByIdAsync(int id);
        Task GenerarPrestamoAsync(int personaId, int materialId);
        Task RegistrarDevolucionAsync(int prestamoId);
    }
}
