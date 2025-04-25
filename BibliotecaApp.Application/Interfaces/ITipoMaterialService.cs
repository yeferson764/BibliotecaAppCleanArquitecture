using BibliotecaApp.Application.DTOs;

namespace BibliotecaApp.Application.Interfaces
{
    public interface ITipoMaterialService
    {
        Task<IEnumerable<TipoMaterialDto>> GetAllAsync();
        Task<TipoMaterialDto?> GetByIdAsync(int id);
        Task AddAsync(TipoMaterialDto dto);
        Task UpdateAsync(int id, TipoMaterialDto dto);
        Task DeleteAsync(int id);
    }
}
