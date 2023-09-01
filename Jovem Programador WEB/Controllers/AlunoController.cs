using Jovem_Programador_WEB.Data.Repositorio;
using Jovem_Programador_WEB.Data.Repositorio.Interfaces;
using Jovem_Programador_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Jovem_Programador_WEB.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAlunoRepositorio _alunoRepositorio;
        public AlunoController(IConfiguration configuration, IAlunoRepositorio alunoRepositorio)
        {
            _configuration = configuration;
            _alunoRepositorio = alunoRepositorio;
        }
        public IActionResult Aluno()
        {
            var aluno = _alunoRepositorio.BuscarAlunos();
            return View(aluno);
        }
        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            Endereco endereco = new Endereco();

            try
            {
                cep = cep.Replace("-", "");



                using var client = new HttpClient();
                var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");

                if (result.IsSuccessStatusCode)
                {
                    endereco = JsonSerializer.Deserialize<Endereco>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });

                    ViewData["MsgSucess"] = "Sucesso na busca do endereço!";
                }
                else
                {
                    ViewData["MsgErr"] = "!Erro na busca do endereço!";
                }
            }
            catch (Exception)
            {
                throw;
            }


            return View("Endereco", endereco);
        }
        public IActionResult AdicionarAluno()
        {
            return View();
        }

        public IActionResult InserirAluno(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.InserirAluno(aluno);
                TempData["MsgSucesso"] = "Aluno adicionado com sucesso";
            }
            catch (Exception ex)
            {
                TempData["MsgErro"] = "Erro ao inserir aluno";
            }
            

            return RedirectToAction("Aluno");
        }
        public IActionResult Editar(int id)
        {
            var aluno = _alunoRepositorio.BuscarId(id);
            return View("EditarAluno", aluno);
        }

        public IActionResult EditarAluno(Aluno aluno)
        {
            _alunoRepositorio.EditarAluno(aluno);
            return RedirectToAction("Aluno",aluno);
        }

        public IActionResult ExcluirAluno(Aluno aluno)
        {
            _alunoRepositorio.DeletarAluno(aluno);
            return RedirectToAction("Aluno");
        }

    }

    
}
