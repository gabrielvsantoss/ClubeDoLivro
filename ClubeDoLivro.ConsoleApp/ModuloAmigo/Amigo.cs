

using ClubeDoLivro.ConsoleApp.ModuloRevista;
using System.Net.Mail;

namespace ClubeDoLivro.ConsoleApp.ModuloAmigo
{
    public class Amigo
    {

        public string nomeCompleto;
        public string nomeResponsavel;
        public string telefone;
        public string[] Revistas = new string[100];

        public Revista revistaCadastradaEmUmAmigo = new Revista("", 1,1, "");
        public bool podeFazerEmprestimo = false;
        public int quantidadeDeRevistasCadastradasEmUmAmigo = 0;


        public Amigo(string NomeCompleto, string NomeResponsavel, string Telefone)
        {
            nomeCompleto = NomeCompleto;
            nomeResponsavel = NomeResponsavel;
            telefone = Telefone;            
        }


        public string verificarDados(string NomeCompleto, string NomeResponsavel, string Telefone)
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(NomeCompleto))
                erros += "O campo 'Nome' é obrigatório.\n";

            if (NomeCompleto.Length < 3)
                erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";

            if (string.IsNullOrWhiteSpace(NomeResponsavel))
                erros += "O campo 'Nome Responsavel' é obrigatório.\n";


            if (NomeResponsavel.Length < 3)
                erros += "O campo 'Nome Responsavel' precisa conter ao menos 3 caracteres.\n";

            if (string.IsNullOrWhiteSpace(Telefone))
                erros += "O campo 'Telefone' é obrigatório.\n";

            if (Telefone.Length < 12)
                erros += "O campo 'Telefone' deve seguir o formato 00 0000-0000.";

            return erros;
        }

      
    }
}
