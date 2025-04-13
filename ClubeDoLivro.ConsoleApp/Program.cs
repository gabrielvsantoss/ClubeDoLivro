using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using ClubeDoLivro.ConsoleApp.ModuloRevista;
using ClubeDoLivro.ConsoleApp.ModuloEmprestimo;
using ClubeDoLivro.ConsoleApp.ModuloCaixa;
using ClubeDoLivro.ConsoleApp.ModuloCompartilhado;

namespace ClubeDoLivro.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioRevista repositorioRevista = new RepositorioRevista();
            TelaRevista telaRevista = new TelaRevista(repositorioRevista);

            TelaCompartilhada telaPrincipal = new TelaCompartilhada();
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            TelaAmigo telaAmigo = new TelaAmigo(telaRevista, repositorioRevista);

            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioAmigo,repositorioRevista,telaRevista,telaAmigo);

            while (true)
            {

                int opcaoPrincipal = telaPrincipal.MenuPrincipal();

                if (opcaoPrincipal == 1)
                {
                    while (true)
                    {
                        Console.Clear();
                        int opcaoAmigo = telaAmigo.MenuAmigo();

                        if (opcaoAmigo == 1)
                            telaAmigo.CadastrarNovoAmigo();

                        else if (opcaoAmigo == 2)
                            telaAmigo.EditarAmigo();

                        else if (opcaoAmigo == 3)
                            telaAmigo.ExcluirAmigo();

                        else
                            break;
                    }
                }

                else if (opcaoPrincipal == 2)
                {
                    while (true)
                    {
                        Console.Clear();
                        int opcaoRevista = telaRevista.MenuRevista();

                        if (opcaoRevista == 1)
                            telaRevista.CadastrarRevista();

                        else if (opcaoRevista == 2)
                            telaRevista.EditarRevista();

                        else if (opcaoRevista == 3)
                            telaRevista.ExcluirRevista();

                        else
                            break;
                    }

                }

                else if (opcaoPrincipal == 3)
                {
                    Console.Clear();
                    int opcaoEmprestimo = telaEmprestimo.MenuEmprestimo();

                    if
                }
            }

        }
    }
}
