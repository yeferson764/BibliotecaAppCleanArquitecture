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

        public void Update(Material material)
        {
            _context.Materiales.Update(material);
            _context.SaveChangesAsync();
        }

        public void Delete(Material material)
        {
            _context.Materiales.Remove(material);
            _context.SaveChangesAsync();
        }
    }
}
