using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.TabelasDeCampeonato
{
  public class Final
  {
    private const int QuantidadeDeFilmePermitido = 2;
    public List<Filme> Filmes { get; private set; }

    public Final(List<Filme> filmes)
    {
      new ExcecaoDeDominio()
        .Quando(filmes.Count() != QuantidadeDeFilmePermitido, "Para realizar a final é necessário ter 2 filmes")
        .Lancar();
      Filmes = filmes;
    }

    public Filme ObterVencedor()
    {
      var maiorNota = Filmes.Max(filme => filme.Nota);
      return Filmes.First(filme => filme.Nota == maiorNota);
    }


  }
}