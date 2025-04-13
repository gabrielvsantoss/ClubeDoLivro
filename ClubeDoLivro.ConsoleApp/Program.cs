using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using ClubeDoLivro.ConsoleApp.ModuloCompartilhado;
using ClubeDoLivro.ConsoleApp.ModuloLivro;

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
            TelaAmigo TelaAmigo = new TelaAmigo(telaRevista, repositorioRevista);

            while (true)
            {

                int opcaoPrincipal = telaPrincipal.MenuPrincipal();

                if (opcaoPrincipal == 1)
                {
                    while (true)
                    {
                        Console.Clear();
                        int opcaoAmigo = TelaAmigo.MenuAmigo();

                        if (opcaoAmigo == 1)
                            TelaAmigo.CadastrarNovoAmigo();

                        else if (opcaoAmigo == 2)
                            TelaAmigo.EditarAmigo();

                        else if (opcaoAmigo == 3)
                            TelaAmigo.ExcluirAmigo();

                        else if (opcaoAmigo == 4)
                            TelaAmigo.EmprestarRevistaAmigo();

                        else if (opcaoAmigo == 5)
                            TelaAmigo.ExibirRevistasCadastradasEmUmAmigo();

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
            }

        }
    }
}
