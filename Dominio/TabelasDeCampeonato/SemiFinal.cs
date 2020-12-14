using System.Collections.Generic;
using System.Linq;

namespace Dominio.TabelasDeCampeonato
{
    public class SemiFinal
    {
        public List<Filme> Filmes { get; private set; }

        public SemiFinal(List<Filme> filmes)
        {
            Filmes = filmes;
        }

        public Dictionary<string, List<Filme>> ObterGrupos(){
            var grupos = new Dictionary<string, List<Filme>>{
                {Filmes[0].Id + Filmes[1].Id, new List<Filme>{Filmes[0], Filmes[1] }},
                {Filmes[2].Id + Filmes[3].Id, new List<Filme>{Filmes[2], Filmes[3] }}
            };
            return grupos;
        }

        public List<Filme> obterVencedores(){
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