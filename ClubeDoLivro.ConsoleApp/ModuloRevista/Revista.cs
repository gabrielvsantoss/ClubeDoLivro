

using ClubeDoLivro.ConsoleApp.ModuloAmigo;

namespace ClubeDoLivro.ConsoleApp.ModuloRevista
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

        public string ValidarDados(string TituloRevista, int NumeroEdicao, int AnoPublicacao)
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(TituloRevista))
                erros += "O campo 'Titulo' é obrigatório.\n";

            if (TituloRevista.Length < 3)
                erros += "O campo 'Titulo' precisa conter ao menos 3 caracteres.\n";

            if (NumeroEdicao == 0)
                erros += "O campo 'Numero Edicão' é obrigatório.\n";

            if (NumeroEdicao < 0)
                erros += "O campo 'Numero Edicão' deve ter um valor positivo.\n";

            if (AnoPublicacao == 0)
                erros += "O campo 'Ano Publicação' é obrigatório.\n";

            if (AnoPublicacao < 0)
                erros += "O campo 'Ano Publicação' deve ter um valor positivo.\n";


            return erros;
        }

    }
}
