using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio
{
    public class ExcecaoDeDominio
    {
        public List<string> MensagensDeErros { get; private set; }
        public ExcecaoDeDominio()
        {
            MensagensDeErros = new List<string>();
        }

        public ExcecaoDeDominio Quando(bool condicao, string mensagemDeErro)
        {
            if (condicao)
            {
                MensagensDeErros.Add(mensagemDeErro);
            }
            return this;
        }

        public void Lancar()
        {
            if (MensagensDeErros.Count() > 0 )
            {
                throw new Exception(MensagensDeErros.First());
            }
        }
    }
}