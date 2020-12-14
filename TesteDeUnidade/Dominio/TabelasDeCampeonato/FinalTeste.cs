using System.Collections.Generic;
using Dominio;
using Dominio.TabelasDeCampeonato;
using NUnit.Framework;

namespace TesteDeUnidade.Dominio.TabelasDeCampeonato
{
  public class FinalTeste
  {
    [Test]
    public void DeveObterOVencedor()
    {
      var filmes = new List<Filme>{
                new Filme("1", "Marcia a louca", 2020, 6),
                new Filme("2", "Deu a louca na chapeuzinho", 2020, 8)
            };
      var vencedorEsperado = filmes[1];
      var final = new Final(filmes);

      var vencedorEncontrado = final.obterVencedor();

      Assert.AreEqual(vencedorEsperado, vencedorEncontrado);
    }
  }
}