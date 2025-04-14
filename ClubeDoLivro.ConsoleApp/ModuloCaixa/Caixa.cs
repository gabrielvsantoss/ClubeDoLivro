
using ClubeDoLivro.ConsoleApp.ModuloRevista;

namespace ClubeDoLivro.ConsoleApp.ModuloCaixa
{
    public class Caixa
    {
        public string etiqueta;
        public string cor;
        public int diasEmprestimo;
        public Revista[] revistas;
        public int contadorRevistas;
        public Caixa(string Etiqueta, string Cor, int DiasEmprestimo, Revista[] revistas)
        {
            etiqueta = Etiqueta;
            cor = Cor;
            diasEmprestimo = DiasEmprestimo;
            this.revistas = revistas;
        }

        public string ValidarDados()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(etiqueta))
                erros += "O campo 'Etiqueta' é obrigatório.\n";
            else if (etiqueta.Length > 50)
                erros += "O campo 'Etiqueta' deve ter no máximo 50 caracteres.\n";

            if (string.IsNullOrWhiteSpace(cor))
                erros += "O campo 'Cor' é obrigatório.\n";

            if (diasEmprestimo <= 0)
                erros += "O campo 'Dias de Empréstimo' deve ser um número positivo.\n";

            return erros;
        }
    }
}
