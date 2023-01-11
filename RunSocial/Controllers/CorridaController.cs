using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunSocial.Data;
using RunSocial.Models;

namespace RunSocial.Controllers
{
    public class CorridaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CorridaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Corrida> corridas = _context.Corridas.ToList();

            return View(corridas);
        }

        public IActionResult Details(int id)
        {
            Corrida corrida = _context.Corridas.Include(a => a.Endereco).FirstOrDefault(x => x.Id == id);

            return View(corrida);
        }
    }
}
