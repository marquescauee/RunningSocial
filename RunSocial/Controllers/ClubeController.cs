using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunSocial.Data;
using RunSocial.Interfaces;
using RunSocial.Models;

namespace RunSocial.Controllers
{
    public class ClubeController : Controller
    {
		private readonly IClubeRepository _clubeRepository;

		public ClubeController(IClubeRepository clubeRepository)
        {
			_clubeRepository = clubeRepository;
		}

        public async Task<IActionResult> Index()
        {
            IEnumerable<Clube> clubes = await _clubeRepository.GetAll();

            return View(clubes);
        }

        public async Task<IActionResult> Details(int id)
        {
            Clube clube = await _clubeRepository.GetByIdAsync(id);

            return View(clube);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Clube clube)
        {
            if(!ModelState.IsValid)
            {
                return View(clube);
            }

            _clubeRepository.Add(clube);

            return RedirectToAction("Index");
        }
    }
}
