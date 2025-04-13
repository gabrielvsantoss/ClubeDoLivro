

using ClubeDoLivro.ConsoleApp.ModuloAmigo;

namespace ClubeDoLivro.ConsoleApp.ModuloLivro
{
   public class Revista
    {
        public string tituloRevista;
        public int numeroEdicao;
        public int anoPublicacao;
        public Revista( string TituloRevista, int NumeroEdicao, int AnoPublicacao)
        {
            tituloRevista = TituloRevista;
            numeroEdicao = NumeroEdicao;
            anoPublicacao = AnoPublicacao;
        }


    }
}
