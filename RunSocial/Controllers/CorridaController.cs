using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunSocial.Data;
using RunSocial.Interfaces;
using RunSocial.Models;
using RunSocial.Repository;

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Corrida corrida)
        {
            if (!ModelState.IsValid)
            {
                return View(corrida);
            }

            _corridaRepository.Add(corrida);

            return RedirectToAction("Index");
        }

		public async Task<IActionResult> Edit(int id)
		{
			Corrida corrida = await _corridaRepository.GetByIdAsync(id);

			if (corrida == null) return View("Error");

			return View(corrida);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, Corrida corrida)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Failed to edit");
				return View("Edit", corrida);
			}

			Corrida corridaEditada = await _corridaRepository.GetByIdAsync(id);

			if (corridaEditada != null)
			{
				corridaEditada.Id = corrida.Id;
				corridaEditada.Titulo = corrida.Titulo;
				corridaEditada.Descricao = corrida.Descricao;
				corridaEditada.Imagem = corrida.Imagem;
				corridaEditada.EnderecoId = corrida.EnderecoId;
				corridaEditada.Endereco = corrida.Endereco;

				_corridaRepository.Update(corridaEditada);

				return RedirectToAction("Index");
			}
			else
			{
				return View(corrida);
			}
		}
	}
}
