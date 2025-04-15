using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using ClubeDoLivro.ConsoleApp.ModuloRevista;


namespace ClubeDoLivro.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimo
    {
        public RepositorioRevista repositorioRevista;
        public RepositorioAmigo repositorioAmigo;
        public DateTime[] dias = new DateTime[100];
        public Emprestimo(RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
        {
            this.repositorioAmigo = repositorioAmigo;
            this.repositorioRevista = repositorioRevista;
        }
    }
}
