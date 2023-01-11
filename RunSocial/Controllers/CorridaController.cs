using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunSocial.Data;
using RunSocial.Interfaces;
using RunSocial.Models;

namespace RunSocial.Controllers
{
    public class CorridaController : Controller
    {
		private readonly ICorridaRepository _corridaRepository;

		public CorridaController(ICorridaRepository corridaRepository)
        {
			_corridaRepository = corridaRepository;
		}

        public async Task<IActionResult> Index()
        {
            IEnumerable<Corrida> corridas = await _corridaRepository.GetAll();

            return View(corridas);
        }

        public async Task<IActionResult> Details(int id)
        {
            Corrida corrida = await _corridaRepository.GetByIdAsync(id);

            return View(corrida);
        }
    }
}
