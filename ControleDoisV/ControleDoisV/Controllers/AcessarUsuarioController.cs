using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDoisV.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ControleDoisV.Controllers
{
    public class AcessarUsuarioController : Controller
    {
        private readonly UserManager<UserApplication> _userManager;
        private readonly SignInManager<UserApplication> _signInManager;
        private readonly ILogger _logger;

        public AcessarUsuarioController(UserManager<UserApplication> userManager
            , SignInManager<UserApplication> signInManager
            , ILogger logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Acessar(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Acessar(AcessoUsuarioViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Senha, model.LembrarDeMim, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Usuário Autenticado");
                    return RedirectToLocal(returnUrl);
                }
            }
            ModelState.AddModelError(string.Empty, "Fallha na tentativa de Login");
            return View(model);
        }

        private void AddErros(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Sair()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("Usuario realizou logout");
            return RedirectToAction(nameof(HomeController), "Index");
        }
    }
}