using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.TabelasDeCampeonato
{
    public class Final
    {
        public List<Filme> Filmes { get; private set; }

        public Final(List<Filme> filmes)
        {
            Filmes = filmes;
        }

        public Filme obterVencedor(){
            var maiorNota =  Filmes.Max(filme =>filme.Nota);
            return Filmes.First(filme => filme.Nota == maiorNota);
        }

        
    }
}