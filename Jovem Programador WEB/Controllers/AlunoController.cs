using Jovem_Programador_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Jovem_Programador_WEB.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;
        public AlunoController(IConfiguration configuration)
        {
            _configuration = configuration;
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
                    ViewData["MsgErro"] = "!Erro na busca do endereço!";
                }
            }
            catch (Exception)
            {
                throw;
            }


            return View("Endereco", endereco);
        }
            public IActionResult Aluno()
            {
                return View();
            }
        public IActionResult AdicionarAluno()
        {
            return View();
        }
    }
}
