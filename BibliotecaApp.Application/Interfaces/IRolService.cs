using BibliotecaApp.Application.DTOs.RolDtos;

namespace BibliotecaApp.Application.Interfaces
{
    public interface IRolService
    {
        Task<IEnumerable<RolDto>> GetAllAsync();
        Task<RolDto?> GetByIdAsync(int id);
        Task AddAsync(RolCreateDto dto);
        Task UpdateAsync(int id, RolDto dto);
        Task DeleteAsync(int id);
    }
}
