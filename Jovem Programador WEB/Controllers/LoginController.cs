using Jovem_Programador_WEB.Data.Repositorio.Interfaces;
using Jovem_Programador_WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jovem_Programador_WEB.Controllers
{
    
    public class LoginController : Controller
    {
		private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
		{
			_usuarioRepositorio = usuarioRepositorio;
		}

		public IActionResult TelaLogin()
        {
            return View();
        }
        public IActionResult BuscarUsuario(Usuario usuario)
        {
            try
            {
                var acesso = _usuarioRepositorio.ValidarLogin(usuario);
                if (acesso != null)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    TempData["MsgErro"] = "Senha ou Email Incorreto! Tente Novamente...";
                }
            } 
            catch (Exception)
            {

                throw;
            }

            return View("TelaLogin");
        }
    }
}
