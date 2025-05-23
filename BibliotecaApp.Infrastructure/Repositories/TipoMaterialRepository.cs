﻿using BibliotecaApp.Domain.Interfaces.Repositories;
using BibliotecaApp.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApp.Infrastructure.Repositories
{
    public class TipoMaterialRepository : ITipoMaterialRepository
    {
        private readonly BibliotecaDbContext _context;

        public TipoMaterialRepository(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoMaterial>> GetAllAsync() =>
            await _context.TipoMateriales.ToListAsync();

        public async Task<TipoMaterial?> GetByIdAsync(int id) =>
            await _context.TipoMateriales.FindAsync(id);

        public async Task AddAsync(TipoMaterial tipoMaterial)
        {
            await _context.TipoMateriales.AddAsync(tipoMaterial);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TipoMaterial tipoMaterial)
        {
            _context.TipoMateriales.Update(tipoMaterial);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TipoMaterial tipoMaterial)
        {
            _context.TipoMateriales.Remove(tipoMaterial);
            await _context.SaveChangesAsync();
        }

    }
}
