using System.Collections.Generic;
using System.Linq;
using Dominio;
using Dominio.TabelasDeCampeonato;
using Infraestrutura.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CopaFilmeController : ControllerBase
  {

    [HttpGet]
    public List<Filme> ObterTodos()
    {
      var filmes = AdaptadorCopaFilmeHttp.Obter();
      return filmes;
    }

    [HttpPost]
    public List<Filme> ObterVencedor(List<Filme> filmes)
    {
      var vencedoresDaQuarta = new QuartaDeFinal(filmes).ObterVencedores();
      var vencedoresDaSemi = new SemiFinal(vencedoresDaQuarta).ObterVencedores();
      var vencedor = new Final(vencedoresDaSemi).ObterVencedor();
      var vice = vencedoresDaSemi.First(filme => filme.Id != vencedor.Id);
      return new List<Filme> { vencedor, vice };
    }
  }
}
