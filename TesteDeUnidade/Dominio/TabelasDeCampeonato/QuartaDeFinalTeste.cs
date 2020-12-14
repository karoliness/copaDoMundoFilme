using System.Collections.Generic;
using System.Linq;
using Dominio;
using Dominio.TabelasDeCampeonato;
using NUnit.Framework;

namespace TesteDeUnidade.Dominio.TabelasDeCampeonato
{
  public class QuartaDeFinalTeste
  {
    private List<Filme> Filmes;
    [SetUp]
    public void SetUp(){
       Filmes = new List<Filme>{
                new Filme("1", "Abacate", 2020, 9.5m),
                new Filme("2", "Barao vermelho", 2020, 8.5m),
                new Filme("3", "Vanessa ambulante", 2020, 7.5m),
                new Filme("4", "Coelho maldito", 2020, 6.5m),
                new Filme("5", "Flor ambulante", 2020, 3.5m),
                new Filme("6", "Dora aventureira", 2020, 2.5m),
                new Filme("7", "Quinto elemento", 2020, 6.5m),
                new Filme("8", "Castelo maravilhoso", 2020, 4.5m)
            };
    }

    [Test]
    public void DeveCriarQuartaDeFinalComFilmesOrdenadosAlfabeticamente()
    {
      var filmesEsperados = Filmes.OrderBy(filme => filme.Titulo).ToList();

      var quartaDeFinal = new QuartaDeFinal(Filmes);

      CollectionAssert.AreEqual(filmesEsperados, quartaDeFinal.Filmes);
    }

    [Test]
    public void DeveObterGrupos()
    {
      var grupoEsperado = new Dictionary<string, List<Filme>>{
            { "13", new List<Filme>{Filmes[0], Filmes[2]} },
            { "27", new List<Filme>{Filmes[1], Filmes[6]} },
            { "85", new List<Filme>{Filmes[7], Filmes[4]} },
            { "46", new List<Filme>{Filmes[3], Filmes[5]} }
        };
      var quartaDeFinal = new QuartaDeFinal(Filmes);

      var grupoEncontrado = quartaDeFinal.ObterGrupos();

      CollectionAssert.AreEqual(grupoEsperado, grupoEncontrado);
    }

    [Test]
    public void DeveObterVencedoresDaQuartaDeFinal()
    {
      var grupoEsperado = new Dictionary<string, List<Filme>>{
            { "13", new List<Filme>{Filmes[0], Filmes[2]} },
            { "27", new List<Filme>{Filmes[1], Filmes[6]} },
            { "85", new List<Filme>{Filmes[7], Filmes[4]} },
            { "46", new List<Filme>{Filmes[3], Filmes[5]} }
        };
      var vencedoresEsperados = new List<Filme>{
          Filmes[0],
          Filmes[1],
          Filmes[7],
          Filmes[3]
      };
      var quartaDeFinal = new QuartaDeFinal(Filmes);

      var vencedoresEncontrados = quartaDeFinal.ObterVencedores();

      CollectionAssert.AreEqual(vencedoresEsperados, vencedoresEncontrados);
    }
  }
}