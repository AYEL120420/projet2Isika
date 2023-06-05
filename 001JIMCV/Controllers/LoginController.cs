using _001JIMCV.Models;
using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Dals;
using _001JIMCV.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace _001JIMCV.Controllers
{
    public class LoginController : Controller
    {
        private LoginDal dal;
        public LoginController()
        {
            dal = new LoginDal();
        }
        public IActionResult Index()
        {
            LoginViewModel viewModel = new LoginViewModel { Authentified = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentified)
            {
                viewModel.User = dal.GetUser(HttpContext.User.Identity.Name);
                return View(viewModel);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = dal.Authentify(viewModel.User.Email, viewModel.User.Password);
                if (user != null)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, user.Role.ToString()),

                    };

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });

                    HttpContext.SignInAsync(userPrincipal);

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return Redirect("/");
                }

                ModelState.AddModelError("User.Email", "Email et/ou mot de passe incorrect(s)");

            }
            return View(viewModel);
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccount(User user)
        {
            if (ModelState.IsValid)
            {
                int id = dal.AddUser(user.Name, user.Email, user.Password, user.Role);

                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                };

                var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return Redirect("/");
            }
            return View(user);
        }

        public ActionResult Deconnection()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }

}
