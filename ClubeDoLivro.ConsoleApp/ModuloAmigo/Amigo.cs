

using ClubeDoLivro.ConsoleApp.ModuloRevista;

namespace ClubeDoLivro.ConsoleApp.ModuloAmigo
{
    public class Amigo
    {
        public string nomeCompleto;
        public string nomeResponsavel;
        public string telefone;
        public string[] Revistas = new string[100];
        public Revista[] revistasCadastradasEmUmAmigo = new Revista[100];
        public int quantidadeDeRevistasCadastradasEmUmAmigo = 0;


        public Amigo(string NomeCompleto, string NomeResponsavel, string Telefone)
        {
            nomeCompleto = NomeCompleto;
            nomeResponsavel = NomeResponsavel;
            telefone = Telefone;
        }

    }
}
