using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApp.Domain.Interfaces.Repositories
{
    public interface IPrestamoRepository
    {
        Task<IEnumerable<Prestamo>> GetAllAsync();
        Task<Prestamo?> GetByIdAsync(int id);
        Task<IEnumerable<Prestamo>> GetPrestamosActivosAsync();
        Task<IEnumerable<Prestamo>> GetPrestamosDevueltosAsync();
        Task<IEnumerable<Prestamo>> GetPrestamosActivosPorPersonaAsync(int personaId);
        Task AddAsync(Prestamo prestamo);
        void Update(Prestamo prestamo);
    }
}
