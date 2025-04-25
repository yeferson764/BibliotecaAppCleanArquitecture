using BibliotecaApp.Domain.Interfaces.Repositories;
using BibliotecaApp.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApp.Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly BibliotecaDbContext _context;

        public PersonaRepository(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> GetAllAsync() =>
            await _context.Personas.Include(p => p.Rol).ToListAsync();

        public async Task<Persona?> GetByIdAsync(int id) =>
            await _context.Personas.Include(p => p.Rol).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Persona?> GetByCedulaAsync(string cedula) =>
            await _context.Personas.Include(p => p.Rol).FirstOrDefaultAsync(p => p.Cedula == cedula);

        public async Task AddAsync(Persona persona)
        {
            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();
        }

        public void Update(Persona persona)
        {
            _context.Personas.Update(persona);
            _context.SaveChangesAsync();
        }

        public void Delete(Persona persona)
        {
            _context.Personas.Remove(persona);
            _context.SaveChangesAsync();
        }
    }
}
