using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;
using Dominio.TabelasDeCampeonato;
using NUnit.Framework;

namespace TesteDeUnidade.Dominio.TabelasDeCampeonato
{
  public class FinalTeste
  {
    private List<Filme> Filmes;
    [SetUp]
    public void SetUp(){
      Filmes = new List<Filme>{
                new Filme("1", "Marcia a louca", 2020, 6),
                new Filme("2", "Deu a louca na chapeuzinho", 2020, 8)
            };
    }
    [Test]
    public void DeveObterOVencedor()
    {
      var vencedorEsperado = Filmes[1];
      var final = new Final(Filmes);

      var vencedorEncontrado = final.ObterVencedor();

      Assert.AreEqual(vencedorEsperado, vencedorEncontrado);
    }

    [Test]
    public void DeveValidarAQuantidadeDeFilmeQuandoForSemiFinal(){
      Filmes.Add(new Filme("3", "O escolhido", 2020, 10m));

      Assert.Throws<Exception>(() => new Final(Filmes), "Para realizar a final é necessário ter 2 filmes");
    }

    [Test]
    public void DeveValidarAQuantidadeDeFilmeQuandoForIgualAOitoNaFinal(){
      var final = new Final(Filmes);      
      
      Assert.AreEqual(Filmes.Count(), final.Filmes.Count());
    }
  }
}