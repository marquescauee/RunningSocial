using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunSocial.Data;
using RunSocial.Models;

namespace RunSocial.Controllers
{
    public class ClubeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClubeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Clube> clubes = _context.Clubes.ToList();

            return View(clubes);
        }

        public IActionResult Details(int id)
        {
            Clube clube = _context.Clubes.Include(a => a.Endereco).FirstOrDefault(x => x.Id == id);

            return View(clube);
        }
    }
}
