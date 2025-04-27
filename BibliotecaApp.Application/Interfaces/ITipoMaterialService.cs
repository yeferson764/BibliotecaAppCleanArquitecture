using BibliotecaApp.Application.DTOs.TipoMaterialDtos;

namespace BibliotecaApp.Application.Interfaces
{
    public interface ITipoMaterialService
    {
        Task<IEnumerable<TipoMaterialDto>> GetAllAsync();
        Task<TipoMaterialDto?> GetByIdAsync(int id);
        Task AddAsync(TipoMaterialCreateAndUpdateDto dto);
        Task UpdateAsync(int id, TipoMaterialCreateAndUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
