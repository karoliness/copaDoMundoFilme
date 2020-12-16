using System.Collections.Generic;
using System.Linq;

namespace Dominio.TabelasDeCampeonato
{
  public class SemiFinal
  {
    private const int QuantidadeDeFilmePermitido = 4;
    public List<Filme> Filmes { get; private set; }

    public SemiFinal(List<Filme> filmes)
    {
      new ExcecaoDeDominio().
        Quando(filmes.Count() > QuantidadeDeFilmePermitido, "Para realizar a semi final é necessário ter 4 filmes")
        .Lancar();
      Filmes = filmes;
    }

    public Dictionary<string, List<Filme>> ObterGrupos()
    {
      var grupos = new Dictionary<string, List<Filme>>{
                {Filmes[0].Id + Filmes[1].Id, new List<Filme>{Filmes[0], Filmes[1] }},
                {Filmes[2].Id + Filmes[3].Id, new List<Filme>{Filmes[2], Filmes[3] }}
            };
      return grupos;
    }

    public List<Filme> ObterVencedores()
    {
      var grupos = ObterGrupos();
      var vencedores = new List<Filme>();
      foreach (var grupo in grupos)
      {
        var maiorNota = grupo.Value.Max(g => g.Nota);
        var vencedor = grupo.Value.First(g => g.Nota == maiorNota);
        vencedores.Add(vencedor);
      }

      return vencedores;
    }
  }
}