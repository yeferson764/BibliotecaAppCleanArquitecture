using BibliotecaApp.Domain.Interfaces.Repositories;
using BibliotecaApp.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApp.Infrastructure.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly BibliotecaDbContext _context;

        public MaterialRepository(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Material>> GetAllAsync() =>
            await _context.Materiales.ToListAsync();

        public async Task<Material?> GetByIdAsync(int id) =>
            await _context.Materiales.FindAsync(id);

        public async Task AddAsync(Material material)
        {
            await _context.Materiales.AddAsync(material);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Material material)
        {
            _context.Materiales.Update(material);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Material material)
        {
            _context.Materiales.Remove(material);
            await _context.SaveChangesAsync();
        }

    }
}
