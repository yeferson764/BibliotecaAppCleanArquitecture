using BibliotecaApp.Application.DTOs;

namespace BibliotecaApp.Application.Interfaces
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialDto>> GetAllAsync();
        Task<MaterialDto?> GetByIdAsync(int id);
        Task AddAsync(MaterialDto dto);
        Task UpdateAsync(int id, MaterialDto dto);
        Task DeleteAsync(int id);
        Task AddStockAsync(int id, int cantidad);
    }
}
