using RunSocial.Models;

namespace RunSocial.Interfaces
{
	public interface IClubeRepository
	{
		Task<IEnumerable<Clube>> GetAll();
		Task<Clube> GetByIdAsync(int id);
		Task<IEnumerable<Clube>> GetClubByCity(string cidade);
		bool Add(Clube clube);
		bool Update(Clube clube);
		bool Delete(Clube clube);
		bool Save();
	}
}
