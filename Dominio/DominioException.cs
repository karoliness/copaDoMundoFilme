using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio
{
    public class DominioException
    {

        public const int QuantidadeMaximaDeSelecaoDeFilmesNaQuartaDeFinal = 8;
        public List<string> MensagensDeErros { get; private set; }


        public DominioException()
        {
            MensagensDeErros = new List<string>();
        }

        public List<String> quantidadeDeFilmesPermitidosParaSelecaoNaQuartafinal(int quantidadeDeFilme, string mensagemDeErro)
        {
            if (quantidadeDeFilme != QuantidadeMaximaDeSelecaoDeFilmesNaQuartaDeFinal)
            {
                MensagensDeErros.Add(mensagemDeErro);
            }
            return MensagensDeErros;
        }

        public lancar()
        {
            if (MensagensDeErros.Count() > 0 )
            {
                throw new Exception(MensagensDeErros.First());
            }
        }

    }
}