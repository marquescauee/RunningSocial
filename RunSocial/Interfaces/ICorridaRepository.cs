using RunSocial.Models;

namespace RunSocial.Interfaces
{
	public interface ICorridaRepository
	{
		Task<IEnumerable<Corrida>> GetAll();
		Task<Corrida> GetByIdAsync(int id);
		Task<IEnumerable<Corrida>> GetAllRacesByCity(string cidade);
		bool Add(Corrida corrida);
		bool Update(Corrida corrida);
		bool Delete(Corrida corrida);
		bool Save();
	}
}
