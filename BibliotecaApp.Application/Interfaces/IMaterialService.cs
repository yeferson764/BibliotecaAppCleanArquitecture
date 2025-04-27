using BibliotecaApp.Application.DTOs.MaterialDtos;

namespace BibliotecaApp.Application.Interfaces
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialDto>> GetAllAsync();
        Task<MaterialDto?> GetByIdAsync(int id);
        Task AddAsync(MaterialCreateAndUpdateDto dto);
        Task UpdateAsync(int id, MaterialCreateAndUpdateDto dto);

        Task DeleteAsync(int id);
        Task AddStockAsync(int id, int cantidad);
    }
}
