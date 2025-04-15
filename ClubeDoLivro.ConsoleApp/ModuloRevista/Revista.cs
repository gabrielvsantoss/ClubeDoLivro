

using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using ClubeDoLivro.ConsoleApp.ModuloCaixa;

namespace ClubeDoLivro.ConsoleApp.ModuloRevista
{
   public class Revista
    {
        public string tituloRevista;
        public int numeroEdicao;
        public DateTime anoPublicacao;
        public string status = "Disponivel";
        public DateTime dataEmprestimo = new DateTime();
        public Revista(string TituloRevista, int NumeroEdicao, DateTime AnoPublicacao, string Status)
        {
            tituloRevista = TituloRevista;
            numeroEdicao = NumeroEdicao;
            anoPublicacao = AnoPublicacao;
        }

        public string ValidarDados(string TituloRevista, int NumeroEdicao, DateTime AnoPublicacao)
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
           
            




            return erros;
        }

    }
}
