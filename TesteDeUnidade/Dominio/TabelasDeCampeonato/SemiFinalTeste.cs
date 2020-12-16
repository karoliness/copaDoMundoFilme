using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;
using Dominio.TabelasDeCampeonato;
using NUnit.Framework;

namespace TesteDeUnidade.Dominio.TabelasDeCampeonato
{
  public class SemiFinalTeste
  {
    private List<Filme> Filmes;

    [SetUp]
    public void SetUp()
    {
      Filmes = new List<Filme>{
              new Filme("1", "Alice no pais das Maravilhas", 2020, 10m),
                new Filme("2", "Boneco de Olinda", 2020, 8.5m),
                new Filme("3", "Castelo maravilhoso", 2020, 6m),
                new Filme("4", "Doidera", 2020, 9m),
          };
    }
    [Test]
    public void DeveObterGruposDaSemiFinal()
    {
      var semiFinal = new SemiFinal(Filmes);
      var grupoEsperado = new Dictionary<string, List<Filme>>{
          {"12", new List<Filme>{Filmes[0], Filmes[1] } },
          {"34", new List<Filme>{Filmes[2], Filmes[3]}}
      };

      var grupoEncontrado = semiFinal.ObterGrupos();

      CollectionAssert.AreEqual(grupoEsperado, grupoEncontrado);
    }

    [Test]
    public void DeveObterVencedoresDaSemiFinal()
    {
      var vencedoresEsperado = new List<Filme>{
            Filmes[0],
            Filmes[3]
        };
      var semiFinal = new SemiFinal(Filmes);

      var vencedoresEncontrados = semiFinal.ObterVencedores();

      CollectionAssert.AreEqual(vencedoresEsperado, vencedoresEncontrados);
    }

    [Test]
    public void DeveValidarAQuantidadeDeFilmeQuandoForSemiFinal()
    {
      Filmes.Add(new Filme("5", "O escolhido", 2020, 10m));

      Assert.Throws<Exception>(() => new SemiFinal(Filmes), "Para realizar a semi final é necessário ter 4 filmes");
    }

    [Test]
    public void DeveValidarAQuantidadeDeFilmeQuandoForIgualAOitoNaSemiFinal(){
      var semiFinal = new SemiFinal(Filmes);

      Assert.AreEqual(Filmes.Count(), semiFinal.Filmes.Count());
    }
  }
}