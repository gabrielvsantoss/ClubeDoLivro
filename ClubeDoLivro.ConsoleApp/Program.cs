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
            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();

            TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);

            TelaRevista telaRevista = new TelaRevista(repositorioRevista, telaCaixa, repositorioCaixa);

            TelaCompartilhada telaPrincipal = new TelaCompartilhada();
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioAmigo, repositorioRevista, telaRevista, telaCaixa, repositorioCaixa);
            TelaAmigo telaAmigo = new TelaAmigo(telaRevista, repositorioRevista, repositorioAmigo, telaEmprestimo);

            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();


            while (true)
            {
                Console.Clear();
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

                        else if (opcaoAmigo == 4)
                        {
                            telaAmigo.VisualizarAmigos();
                            Console.WriteLine("Clique ENTER para continuar");
                            Console.ReadLine();
                        }

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

                        else if (opcaoRevista == 4)
                        {
                            telaRevista.VisualizarRevistas();
                            Console.WriteLine("Clique ENTER para continuar");
                            Console.ReadLine();
                        }

                        else
                            break;
                    }

                }

                else if (opcaoPrincipal == 3)
                {
                    while (true)
                    {
                        Console.Clear();
                        int opcaoEmprestimo = telaEmprestimo.MenuEmprestimo();

                        if (opcaoEmprestimo == 1)
                            telaEmprestimo.CadastrarEmprestimo();

                           

                        else if (opcaoEmprestimo == 2)
                        {
                            telaEmprestimo.VisualizarEmprestimos();
                            Console.WriteLine("Clique ENTER para continuar");
                            Console.ReadLine();
                        }
                        else
                            break;
                    }
                }

                else if (opcaoPrincipal == 4)
                {
                    while (true)
                    {


                        Console.Clear();
                        int opcaoCaixa = telaCaixa.MenuCaixa();

                        if (opcaoCaixa == 1)
                            telaCaixa.CadastrarCaixa();

                        else if (opcaoCaixa == 2)
                        {
                            telaCaixa.VisualizarCaixas();
                            Console.WriteLine("Clique ENTER para continuar");
                            Console.ReadLine();
                        }
                        else
                            break;
                    }
                }
            }

        }
    }
}
