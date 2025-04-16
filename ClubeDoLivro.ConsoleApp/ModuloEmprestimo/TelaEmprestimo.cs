using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using ClubeDoLivro.ConsoleApp.ModuloCaixa;
using ClubeDoLivro.ConsoleApp.ModuloRevista;

namespace ClubeDoLivro.ConsoleApp.ModuloEmprestimo
{
    public class TelaEmprestimo
    {
        public RepositorioAmigo repositorioAmigo;
        public RepositorioRevista repositorioRevista;
        public TelaRevista telaRevista;
        public Revista revista = new Revista(" ", 0, default, "");
        public RepositorioCaixa repositorioCaixa;
        public TelaCaixa telaCaixa;
        public int[] diasRestantes = new int [100];
        
        public TelaEmprestimo(RepositorioAmigo RepositorioAmigoo, RepositorioRevista repositorioRevista, TelaRevista telaRevistaa, TelaCaixa telaCaixa, RepositorioCaixa repositorioCaixa)
        {
            repositorioAmigo = RepositorioAmigoo;
            this.repositorioRevista = repositorioRevista;
            telaRevista = telaRevistaa;
            this.telaCaixa = telaCaixa;
            this.repositorioCaixa = repositorioCaixa;
        }

        public int MenuEmprestimo()
        {

            int opcao;
            Console.WriteLine(" -------------------------------------------------");
            Console.WriteLine("|                Menu Emprestimo                  |");
            Console.WriteLine("|-------------------------------------------------|");
            Console.WriteLine("|[1] - Cadastrar Novo Emprestimo                  |");
            Console.WriteLine("|[2] - Visualizar todos os emprestimos existentes |");
            Console.WriteLine("|[3] - Sair                                       |");
            Console.WriteLine("|------------------------------------------------- ");
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
                    repositorioAmigo.amigosCadastrados[i].revistaCadastradaEmUmAmigo = repositorioRevista.revistasCadastradas[i];
                    if(revistaEncontrada == false)
                        revistaEncontrada = true;
                }
            }

            Console.WriteLine("------------------------------------------------------------------");

            if (!revistaEncontrada)

            {   Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A revista que voce digitou nao esta cadastrada no nosso sistema");
                Console.WriteLine("Aperte ENTER para continuar");
                Console.ResetColor();
                Console.ReadLine();
            }
            else if (revistaEncontrada)
            {
                VisualizarAmigos();
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
                                if (repositorioRevista.revistasCadastradas[i].status == "Indisponivel")
                                    {
                                        Console.WriteLine("Esse amigo ja possui um emprestimo e essa revista nao podera ser entregue a ele.\nAperte ENTER para continuar");
                                        Console.ReadLine();
                                        break;
                                    }

                                Console.WriteLine("Digite a data que esta sendo realizado esse emprstimo para calcularmos a data de devolução (dd/mm/yyyy)");
                                repositorioAmigo.amigosCadastrados[i].revistaCadastradaEmUmAmigo.dataEmprestimo = Convert.ToDateTime(Console.ReadLine()!);
                                Console.ForegroundColor = ConsoleColor.Green;
                                repositorioRevista.revistasCadastradas[i].status = "Indisponivel";

                                Console.WriteLine("Emprestimo realizado com sucesso\nAperte ENTER para continuar");
                                Console.ResetColor();
                                Console.ReadLine();
                                break;
                            }
                    }
                }
            }
        }



        public void VisualizarEmprestimos()
        {
            Console.WriteLine($"Emprestimos cadastrados no sistema:");
            Console.WriteLine(
              "{0, -25} | {1, -25} | {2, -25} | {3, -25}",
           "Amigo", "Revista" , "Data de realização", "Data de Vencimento"
          );
            for (int i = 0; i < repositorioAmigo.amigosCadastrados.Length; i++)
            {
                if (repositorioAmigo.amigosCadastrados[i] == null) continue;

                    if (repositorioAmigo.amigosCadastrados[i].revistaCadastradaEmUmAmigo == null) continue;

                    else
                    {
                   
                        DateTime tempoTotal = repositorioAmigo.amigosCadastrados[i].revistaCadastradaEmUmAmigo.dataEmprestimo.AddDays(repositorioCaixa.caixasCadastradas[i].diasEmprestimo);
                    
                      Console.WriteLine(
                        "{0, -25} | {1, -25} | {2, -25} | {3, -25}",
                        repositorioAmigo.amigosCadastrados[i].nomeCompleto, repositorioAmigo.amigosCadastrados[i].revistaCadastradaEmUmAmigo.tituloRevista, repositorioAmigo.amigosCadastrados[i].revistaCadastradaEmUmAmigo.dataEmprestimo.ToShortDateString(), tempoTotal.ToShortDateString()
                     );
                    }
                
            }

            Console.ReadLine();
        }

        public void VisualizarAmigos()
        {
            Console.WriteLine(
           "{0, -25} | {1, -25} | {2, -25}",
        "Nome Completo", "Nome Responsavel", "Telefone"
       );
            for (int i = 0; i < repositorioAmigo.amigosCadastrados.Length; i++)
            {
                if (repositorioAmigo.amigosCadastrados[i] == null) continue;

                else
                {
                    Console.WriteLine(
            "{0, -25} | {1, -25} | {2, -25} |",
              repositorioAmigo.amigosCadastrados[i].nomeCompleto, repositorioAmigo.amigosCadastrados[i].nomeResponsavel, repositorioAmigo.amigosCadastrados[i].telefone
         );

                }
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
        }

    }
}
