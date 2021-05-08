using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZPOS.UI.Entities;
using ZPOS.UI.Models;
using System;
using Microsoft.AspNetCore.Http;

namespace ZPOS.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginVM model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null && user.Deleted == false)
                {
                    if (user.Status == false) return BadRequest("Este usurio no se encuentra activado para iniciar sesión");

                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (!result.Succeeded) return BadRequest("Usuario o contrasena incorrecta");

                    if (!string.IsNullOrEmpty(model.returnUrl) && Url.IsLocalUrl(model.returnUrl)) return Json(model.returnUrl);
                    else return Json("Home/Index");
                }

                return BadRequest("Usuario o contrasena incorrecta");

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
