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
        public IActionResult Create(Clube clube)
        {
            if(!ModelState.IsValid)
            {
                return View(clube);
            }

            _clubeRepository.Add(clube);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Clube clube = await _clubeRepository.GetByIdAsync(id);

            if (clube == null) return View("Error");

            return View(clube);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Clube clube)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit");
                return View("Edit", clube);
            }

            Clube clubeEditado = await _clubeRepository.GetByIdAsync(id);

            if(clubeEditado != null)
            {
				clubeEditado.Id = clube.Id;
				clubeEditado.Titulo = clube.Titulo;
				clubeEditado.Descricao = clube.Descricao;
				clubeEditado.Imagem = clube.Imagem;
				clubeEditado.EnderecoId = clube.EnderecoId;
				clubeEditado.Endereco = clube.Endereco;

				_clubeRepository.Update(clubeEditado);

				return RedirectToAction("Index");
			} else
            {
                return View(clube);
            }
        }
    }
}
