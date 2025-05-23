﻿using BibliotecaApp.Domain.Interfaces.Repositories;
using BibliotecaApp.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApp.Infrastructure.Repositories
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly BibliotecaDbContext _context;

        public PrestamoRepository(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prestamo>> GetAllAsync() =>
            await _context.Prestamos
                .Include(p => p.Material)
                .Include(p => p.Persona)
                .ToListAsync();

        public async Task<Prestamo?> GetByIdAsync(int id) =>
            await _context.Prestamos
                .Include(p => p.Material)
                .Include(p => p.Persona)
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Prestamo>> GetPrestamosActivosAsync() =>
            await _context.Prestamos
                .Where(p => !p.Devuelto)
                .Include(p => p.Material)
                .Include(p => p.Persona)
                .ToListAsync();

        public async Task<IEnumerable<Prestamo>> GetPrestamosDevueltosAsync() =>
            await _context.Prestamos
                .Where(p => p.Devuelto)
                .Include(p => p.Material)
                .Include(p => p.Persona)
                .ToListAsync();

        public async Task<IEnumerable<Prestamo>> GetPrestamosActivosPorPersonaAsync(int personaId)
        {
            return await _context.Prestamos
                .Include(p => p.Persona)
                .Include(p => p.Material)
                .Where(p => p.PersonaId == personaId && !p.Devuelto)
                .ToListAsync();
        }


        public async Task AddAsync(Prestamo prestamo)
        {
            await _context.Prestamos.AddAsync(prestamo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Prestamo prestamo)
        {
            _context.Prestamos.Update(prestamo);
            await _context.SaveChangesAsync();
        }
    }
}
