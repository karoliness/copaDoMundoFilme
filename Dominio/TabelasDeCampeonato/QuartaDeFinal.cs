using System.Collections.Generic;
using System.Linq;

namespace Dominio.TabelasDeCampeonato
{
  public class QuartaDeFinal
  {
    public List<Filme> Filmes { get; private set; }
    public QuartaDeFinal(List<Filme> filmes)
    {
      Filmes = filmes.OrderBy(filme => filme.Titulo).ToList();
    }

    public Dictionary<string, List<Filme>> ObterGrupos()
    {
      var grupos = new Dictionary<string, List<Filme>>();
      var j = 7;
      for (int i = 0; i < 4; i++)
      {
        var filmeA = Filmes[i];
        var filmeB = Filmes[j];
        var chave = filmeA.Id + filmeB.Id;
        grupos.Add(chave, new List<Filme> { filmeA, filmeB });
        j--;
      }
      return grupos;
    }

    public List<Filme> ObterVencedores(){
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