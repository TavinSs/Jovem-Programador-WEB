using Jovem_Programador_WEB.Models;

namespace Jovem_Programador_WEB.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        List<Aluno> BuscarAlunos();
        void InserirAluno(Aluno aluno);
    }
}
