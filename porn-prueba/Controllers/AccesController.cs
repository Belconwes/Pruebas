using Microsoft.AspNetCore.Mvc;
using porn_prueba.Models;
using porn_prueba.ViewsModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace porn_prueba.Controllers
{
    public class AccesController : Controller
    {
        private readonly PruebaContext _pruebacontext;
        public AccesController(PruebaContext pruebacontext)
        {
            _pruebacontext = pruebacontext;
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Signup(UsuarioVM modelo)
        {
            if (modelo.Contraseña != modelo.Confirmar_contraseña)
            {
                ViewData["Message"] = "The passwords do not match";
                return View();
            }
            Usuario usuario = new Usuario()
            {
                Nombre = modelo.Nombre,
                Apellido = modelo.Apellido,
                Email = modelo.Email,
                Contraseña = modelo.Contraseña
            };
            await _pruebacontext.Usuarios.AddAsync(usuario);
            await _pruebacontext.SaveChangesAsync();

            if(usuario.IdUser != 0)
            {
                return RedirectToAction("Login", "Acces");

            }
            ViewData["Message"] = "No se pudo registrar al usuario";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public PruebaContext Get_pruebacontext()
        {
            return _pruebacontext;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM modelo)
        {
            Usuario? usuario_found = await _pruebacontext.Usuarios
                                    .Where(u =>
                                     u.Email == modelo.Email &&
                                     u.Contraseña == modelo.Contraseña
                                     ).FirstOrDefaultAsync();
            if(usuario_found == null)
            {
                ViewData["Message"] = "No se encontro el usuario solicitado, por favor revise los campos a rellenar";
                return View();
            }
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,usuario_found.Nombre)
                
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties

                );
            return RedirectToAction("Index", "Home");

        }
                                    
        

    }

}
