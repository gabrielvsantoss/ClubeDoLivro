using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using ClubeDoLivro.ConsoleApp.ModuloRevista;

namespace ClubeDoLivro.ConsoleApp.ModuloEmprestimo
{
    public class TelaEmprestimo
    {
        public RepositorioAmigo repositorioAmigo;
        public RepositorioRevista repositorioRevista;
        public TelaRevista telaRevista;
        public TelaAmigo telaAmigo;
        public Revista revista = new Revista(" ", 0, 0, "");
        public TelaEmprestimo(RepositorioAmigo RepositorioAmigoo, RepositorioRevista repositorioRevista, TelaRevista telaRevista, TelaAmigo telaAmigo)
        {
            repositorioAmigo = RepositorioAmigoo;
            this.repositorioRevista = repositorioRevista;
            this.telaRevista = telaRevista;
            this.telaAmigo = telaAmigo;
        }

        public int MenuEmprestimo()
        {

            int opcao;
            Console.WriteLine("-------------------------");
            Console.WriteLine("Menu Emprestimo");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Qual a opção que deseja?");
            Console.WriteLine("1 - Cadastrar Novo Emprestim");
            Console.WriteLine("2 - Editar Emprestimo ja existente");
            Console.WriteLine("3 - Excluir  Emprestimo");
            Console.WriteLine("4 - Visualizar  Emprestimos de um amigo");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("-------------------------");
            Console.Write("Opção: ");
            opcao = Convert.ToInt32(Console.ReadLine());


            return opcao;
        }

        public void CadastrarEmprestimo()
        {

            telaRevista.VisualizarRevistas();

            Console.WriteLine("Qual revista que voce deseja emprestar");
            string revistaEmprestimo = Console.ReadLine()!;
            bool revistaEncontrada = false;


            for (int i = 0; i < repositorioRevista.revistasCadastradas.Length; i++)
            {
                if (repositorioRevista.revistasCadastradas[i] == null) continue;

                else if (repositorioRevista.revistasCadastradas[i].tituloRevista == revistaEmprestimo)
                {
                    repositorioRevista.revistasCadastradas[i].status = "Indisponivel";
                    revista = repositorioRevista.revistasCadastradas[i];
                    revistaEncontrada = true;
                }
            }

            Console.WriteLine("------------------------------------------------------------------");

            if (!revistaEncontrada)
            {
                Console.WriteLine("");
                Console.ReadLine();
            }
            else if (revistaEncontrada)
            {
                telaAmigo.VisualizarAmigos();
                Console.WriteLine("Qual o nome do amigo que deseja emprestar?");
                string amigoEmprestimo = Console.ReadLine()!;

                for (int i = 0; i < repositorioAmigo.amigosCadastrados.Length; i++)
                {
                    if (repositorioAmigo.amigosCadastrados[i] == null) continue;

                    else if (repositorioAmigo.amigosCadastrados[i].nomeCompleto == amigoEmprestimo)
                    {


                        
                            if (repositorioAmigo.amigosCadastrados[i].revistaCadastradaEmUmAmigo == null) continue;

                            else
                            {
                                if (repositorioAmigo.amigosCadastrados[i].revistaCadastradaEmUmAmigo.status == "Indisponivel")
                                    {

                                        Console.WriteLine("Esse amigo ja possui um emprestimo e essa revista nao podera ser entregue a ele.\nAperte ENTER para continuar");
                                        Console.ReadLine();
                                            break
                                        ;
                                    }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Emprestimo realizado com sucesso\nAperte ENTER para continuar");
                                Console.ResetColor();
                                Console.ReadLine();
                                repositorioAmigo.amigosCadastrados[i].revistaCadastradaEmUmAmigo = revista;
                                break;
                            }
                        



                    }
                }
            }


        }

        public void VisualizarEmprestimos()
        {
            telaAmigo.VisualizarAmigos();
            Console.WriteLine("Digite o nome do amigo que deseja visualizar os emprestimos");
            string amigoVisualizado = Console.ReadLine()!;

            if (repositorioAmigo.amigosCadastrados[0] != null)
            {
                for (int i = 0; i < repositorioAmigo.amigosCadastrados.Length; i++)
                {
                    if (repositorioAmigo.amigosCadastrados[i] == null) continue;

                    else if (repositorioAmigo.amigosCadastrados[i].nomeCompleto == amigoVisualizado)
                    {
                        Console.WriteLine($"Livros cadastrados no nome de {amigoVisualizado}");
                        Console.WriteLine(
                          "{0, -25} | {1, -25} | {2, -15}",
                       "Titulo", "Numero Edição", "Ano Publicação"
                      );

                          if (repositorioAmigo.amigosCadastrados[i].revistaCadastradaEmUmAmigo == null) continue;
                            else
                            {
                                Console.WriteLine(
                    "{0, -25} | {1, -25} | {2, -15} |",
                    repositorioAmigo.amigosCadastrados[i].revistaCadastradaEmUmAmigo.tituloRevista, repositorioAmigo.amigosCadastrados[i].revistaCadastradaEmUmAmigo.numeroEdicao, repositorioAmigo.amigosCadastrados[i].revistaCadastradaEmUmAmigo.anoPublicacao
                 );
                            }
                        
                    }


                }
            }
            Console.ReadLine();

        }

    }
}
