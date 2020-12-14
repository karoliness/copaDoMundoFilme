namespace Dominio
{
    public class Filme
    {
        public string Id { get; private set; }
        public string Titulo { get; private set; }
        public int AnoDeLancamento { get; private set; }
        public decimal Nota { get; private set; }

        public Filme(string id, string titulo, int anoDeLancamento, decimal nota)
        {
            Id = id;
            Titulo = titulo;
            AnoDeLancamento = anoDeLancamento;
            Nota = nota;
        }
    }
}
