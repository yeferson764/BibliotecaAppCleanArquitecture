using BibliotecaApp.Application.DTOs;

namespace BibliotecaApp.Application.Interfaces
{
    public interface IRolService
    {
        Task<IEnumerable<RolDto>> GetAllAsync();
        Task<RolDto?> GetByIdAsync(int id);
        Task AddAsync(RolDto dto);
        Task UpdateAsync(int id, RolDto dto);
        Task DeleteAsync(int id);
    }
}
