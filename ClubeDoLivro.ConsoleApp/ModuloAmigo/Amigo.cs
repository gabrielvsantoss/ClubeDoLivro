

namespace ClubeDoLivro.ConsoleApp.ModuloAmigo
{
    public class Amigo
    {
        public string nomeCompleto;
        public string nomeResponsavel;
        public string telefone;
        public string[] Revistas = new string[100];

        public Amigo(string NomeCompleto, string NomeResponsavel, string Telefone)
        {
            nomeCompleto = NomeCompleto;
            nomeResponsavel = NomeResponsavel;
            telefone = Telefone;
        }

    }
}
