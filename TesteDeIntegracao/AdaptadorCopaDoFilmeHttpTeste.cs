using System.Linq;
using Infraestrutura.Servico;
using NUnit.Framework;

namespace TesteDeIntegracao
{
    public class AdaptadorCopaDoFilmeHttpTeste
    {
        [Test]
        public void DeveObterFilmes()
        {
           var filmes = AdaptadorCopaFilmeHttp.Obter();
           
           Assert.IsTrue(filmes.Any());
        }
    }
}