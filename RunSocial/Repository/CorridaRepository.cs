using Microsoft.EntityFrameworkCore;
using RunSocial.Data;
using RunSocial.Interfaces;
using RunSocial.Models;

namespace RunSocial.Repository
{
	public class CorridaRepository : ICorridaRepository
	{
		private readonly ApplicationDbContext _context;

		public CorridaRepository(ApplicationDbContext context)
		{
			_context = context;	
		}

		public bool Add(Corrida corrida)
		{
			_context.Add(corrida);

			return Save();
		}

		public bool Delete(Corrida corrida)
		{
			_context.Remove(corrida);

			return Save();
		}

		public async Task<IEnumerable<Corrida>> GetAll()
		{
			return await _context.Corridas.ToListAsync();
		}

		public async Task<IEnumerable<Corrida>> GetAllRacesByCity(string cidade)
		{
			return await _context.Corridas.Where(c => c.Endereco.Cidade == cidade).ToListAsync();
		}

		public async Task<Corrida> GetByIdAsync(int id)
		{
			return await _context.Corridas.Include(i => i.Endereco).FirstOrDefaultAsync(x => x.Id == id);
		}

		public bool Save()
		{
			int saved = _context.SaveChanges();

			return saved > 0;
		}

		public bool Update(Corrida corrida)
		{
			_context.Update(corrida);

			return Save();
		}
	}
}
