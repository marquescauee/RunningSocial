using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RunSocial.Data;
using RunSocial.Models;

namespace RunSocial.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<Usuario> _userManager;
		private readonly SignInManager<Usuario> _signInManager;
		private readonly ApplicationDbContext _context;

		public AccountController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, ApplicationDbContext context)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
		}

		public IActionResult Login()
		{
			Login response = new Login();

			return View(response);
		}

		[HttpPost]
		public async Task<IActionResult> Login(Login login)
		{
			if (!ModelState.IsValid) return View(login);

			Usuario usuario = await _userManager.FindByEmailAsync(login.EmailAddress);

			if(User != null)
			{
				//Usuário encontrado, checando senha
				bool passworCheck = await _userManager.CheckPasswordAsync(usuario, login.Password);

				if (passworCheck)
				{
					//Senha correta, fazendo login
					var result = await _signInManager.PasswordSignInAsync(usuario, login.Password, false, false);

					if(result.Succeeded)
					{
						return RedirectToAction("Index", "Corrida");
					}
				}
				
				//Senha incorreta
				TempData["Error"] = "Wrong credentials. Please, try again";

				return View(login);
			}

			//Usuário não encontrado
			TempData["Error"] = "Wrong credentials. Please, try again";
			return View(login);
		}

        public IActionResult Register()
        {
            Register response = new Register();

            return View(response);
        }

		[HttpPost]
		public async Task<IActionResult> Register(Register register)
		{
			if (!ModelState.IsValid) return View(register);

			Usuario usuario = await _userManager.FindByEmailAsync(register.EmailAddress);

			if (usuario != null)
			{
				TempData["Error"] = "This email address is already in use";
				return View(register);
			}

			Usuario novoUsuario = new Usuario()
			{
				Email = register.EmailAddress,
				UserName = register.Password,
			};

			var newUserResponse = await _userManager.CreateAsync(novoUsuario, register.Password);

			if(!newUserResponse.Succeeded)
			{
				TempData["Error"] = "Password does not contain the requirements needed";
				return View(register);
			} else
			{
				await _userManager.AddToRoleAsync(usuario, UserRoles.User);
				return RedirectToAction("Index", "Corrida");

			}
			
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Corrida");
		}
    }
}
