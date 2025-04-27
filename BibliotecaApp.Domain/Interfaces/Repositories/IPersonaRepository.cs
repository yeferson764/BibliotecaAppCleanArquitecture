using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApp.Domain.Interfaces.Repositories
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> GetAllAsync();
        Task<Persona?> GetByIdAsync(int id);
        Task<Persona?> GetByCedulaAsync(string cedula);
        Task AddAsync(Persona persona);
        Task UpdateAsync(Persona persona);  
        void Delete(Persona persona);
    }
}
