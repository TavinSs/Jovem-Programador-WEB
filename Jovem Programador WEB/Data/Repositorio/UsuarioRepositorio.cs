using Jovem_Programador_WEB.Data.Repositorio.Interfaces;
using Jovem_Programador_WEB.Models;

namespace Jovem_Programador_WEB.Data.Repositorio
{
	public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContexto _bancoContexto;

	public UsuarioRepositorio(BancoContexto bancoContexto)
	{
		_bancoContexto = bancoContexto;
	}
	public Usuario ValidarLogin(Usuario usuario)
	{
			return _bancoContexto.Usuario.FirstOrDefault(x => x.Email == usuario.Email && x.Senha == usuario.Senha);
	}

	}
}
