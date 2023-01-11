using Microsoft.EntityFrameworkCore;
using RunSocial.Data;
using RunSocial.Interfaces;
using RunSocial.Models;

namespace RunSocial.Repository
{
	public class ClubeRepository : IClubeRepository
	{
		private readonly ApplicationDbContext _context;

		public ClubeRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public bool Add(Clube clube)
		{
			_context.Add(clube);

			return Save();
		}

		public bool Delete(Clube clube)
		{
			_context.Remove(clube);

			return Save();
		}

		public async Task<IEnumerable<Clube>> GetAll()
		{
			return await _context.Clubes.ToListAsync();
		}

		public async Task<Clube> GetByIdAsync(int id)
		{
			return await _context.Clubes.Include(i => i.Endereco).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IEnumerable<Clube>> GetClubByCity(string cidade)
		{
			return await _context.Clubes.Where(c => c.Endereco.Cidade.Contains(cidade)).ToListAsync();
		}

		public bool Save()
		{
			int saved = _context.SaveChanges();

			return saved > 0;
		}

		public bool Update(Clube clube)
		{
			_context.Update(clube);

			return Save();
		}
	}
}
