using System.Collections.Generic;
using Dominio;
using Dominio.TabelasDeCampeonato;
using NUnit.Framework;

namespace TesteDeUnidade.Dominio.TabelasDeCampeonato
{
  public class SemiFinalTeste
  {
    [Test]
    public void DeveObterGruposDaSemiFinal()
    {
      var filmes = new List<Filme>{
              new Filme("1", "Alice no pais das Maravilhas", 2020, 10m),
                new Filme("2", "Boneco de Olinda", 2020, 8.5m),
                new Filme("3", "Castelo maravilhoso", 2020, 6m),
                new Filme("4", "Doidera", 2020, 9m),
          };
      var semiFinal = new SemiFinal(filmes);
      var grupoEsperado = new Dictionary<string, List<Filme>>{
          {"12", new List<Filme>{filmes[0], filmes[1] } },
          {"34", new List<Filme>{filmes[2], filmes[3]}}
      };

      var grupoEncontrado = semiFinal.ObterGrupos();

      CollectionAssert.AreEqual(grupoEsperado, grupoEncontrado);
    }

    [Test]
    public void DeveObterVencedoresDaSemiFinal()
    {
      var filmes = new List<Filme>{
              new Filme("1", "Alice no pais das Maravilhas", 2020, 10m),
                new Filme("2", "Boneco de Olinda", 2020, 8.5m),
                new Filme("3", "Castelo maravilhoso", 2020, 6m),
                new Filme("4", "Doidera", 2020, 9m),
          };
      var vencedoresEsperado = new List<Filme>{
            filmes[0],
            filmes[3]
        };
      var semiFinal = new SemiFinal(filmes);

      var vencedoresEncontrados = semiFinal.obterVencedores();

      CollectionAssert.AreEqual(vencedoresEsperado, vencedoresEncontrados);
    }
  }
}