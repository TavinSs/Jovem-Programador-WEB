using Jovem_Programador_WEB.Models;

namespace Jovem_Programador_WEB.Data.Repositorio.Interfaces
{
	public interface IUsuarioRepositorio
	{
		Usuario ValidarLogin(Usuario usuario);
	}
}
