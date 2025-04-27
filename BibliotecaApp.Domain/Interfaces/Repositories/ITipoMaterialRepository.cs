using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApp.Domain.Interfaces.Repositories
{
    public interface ITipoMaterialRepository
    {
        Task<IEnumerable<TipoMaterial>> GetAllAsync();
        Task<TipoMaterial?> GetByIdAsync(int id);
        Task AddAsync(TipoMaterial tipoMaterial);
        Task UpdateAsync(TipoMaterial tipoMaterial);
        Task DeleteAsync(TipoMaterial tipoMaterial);
    }
}
