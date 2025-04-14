

using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using ClubeDoLivro.ConsoleApp.ModuloCaixa;
using System.Runtime.Serialization;
namespace ClubeDoLivro.ConsoleApp.ModuloRevista
{
    public class TelaRevista
    {
        RepositorioRevista repositorioRevista;
        Revista revistaVerificacao = new Revista("", 1, 1, "");
        public TelaCaixa telaCaixa;
        public RepositorioCaixa repositorioCaixa;
        public TelaRevista(RepositorioRevista repositorioRevistaa, TelaCaixa telaCaixa, RepositorioCaixa repositorioCaixa)
        {
            repositorioRevista = repositorioRevistaa;
            this.telaCaixa = telaCaixa;
            this.repositorioCaixa = repositorioCaixa;
        }
        public int MenuRevista()
        {

            int opcao;
            Console.WriteLine("-------------------------");
            Console.WriteLine("Menu Revistas");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Qual a opção que deseja?");
            Console.WriteLine("1 - Cadastrar Nova Revista");
            Console.WriteLine("2 - Editar Revista ja existente");
            Console.WriteLine("3 - Excluir  Revista");
            Console.WriteLine("4 - Visualizar  Revistas Cadastradas");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("-------------------------");
            Console.Write("Opção: ");
            opcao = Convert.ToInt32(Console.ReadLine());

            return opcao;
        }

        public void CadastrarRevista()
        {
            while (true)
            {
                Console.WriteLine("Qual o titulo da revista que deseja cadastrar");
                string Titulo = Console.ReadLine()!;

                Console.WriteLine("Qual o numero da edição da revista que deseja cadastrar?");
                int NumeroEdicao = Convert.ToInt32(Console.ReadLine()!);

                Console.WriteLine("Qual o ano de publicação da revista que deseja cadastrar? (yyyy/mm/dd)");
                DateTime AnoPublicacao = Convert.ToDateTime((Console.ReadLine()!));

                
                Console.WriteLine();
                string erros = revistaVerificacao.ValidarDados(Titulo, NumeroEdicao, AnoPublicacao);


                if (erros.Length > 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(erros);
                    Console.WriteLine("Clique ENTER para tentar novamente");
                    Console.ResetColor();
                    Console.ReadLine();
                }

                else
                {

                    Revista NovaRevista = new Revista(Titulo, NumeroEdicao, AnoPublicacao, "Disponivel");

                    repositorioRevista.revistasCadastradas[repositorioRevista.contadorRevistas++] = NovaRevista;
                    telaCaixa.VisualizarCaixas();
                    Console.WriteLine("Qual a etiqueta da caixa que deseja cadastrar essa revista?");
                    string etiqueta = Console.ReadLine()!;

                    for (int i = 0; i < repositorioCaixa.caixasCadastradas.Length; i++)
                    {
                        if (repositorioCaixa.caixasCadastradas[i] == null) continue;

                        else if (repositorioCaixa.caixasCadastradas[i].etiqueta == etiqueta)
                        {
                            repositorioCaixa.caixasCadastradas[i].revistas[repositorioCaixa.caixasCadastradas[i].contadorRevistas++] = NovaRevista;
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Revista Cadastrado com sucesso!, Clique ENTER para continuar");
                    Console.ReadLine();
                    Console.ResetColor();
                    break;


                }
            }
        }

        public void EditarRevista()
        {
            VisualizarRevistas();
            Console.WriteLine("Digite o nome Completo do amigo que deseja editar");
            string nomeVerificacao = Console.ReadLine()!;

            bool revistaExiste = repositorioRevista.EditarRevista(nomeVerificacao);

            if (revistaExiste == true)
            {
                Console.WriteLine("Qual vai ser o nome do amigo que esta sendo editado?");
                string Titulo = Console.ReadLine()!;

                Console.WriteLine("Qual vai ser o nome do responsavel do amigo que esta sendo editado?");
                int NumeroEdicao = Convert.ToInt32(Console.ReadLine()!);

                Console.WriteLine("Qual vai ser o telefone do amigo que esta sendo editado?");
                int AnoPublicacao = Convert.ToInt32(Console.ReadLine()!);

                Revista RevistaEditada = new Revista(Titulo, NumeroEdicao, AnoPublicacao, "");
                repositorioRevista.revistasCadastradas[repositorioRevista.contadorRevistas++] = RevistaEditada;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Revista Editada com sucesso!, Clique ENTER para continuar");
                Console.ResetColor();
            }
        }



        public void VisualizarRevistas()
        {
            Console.WriteLine(
            "{0, -20} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
         "Titulo", "Numero Edição", "Ano Publicação", "Status", "Caixa Pertente"
        );
            for (int i = 0; i < repositorioRevista.revistasCadastradas.Length; i++)
            {
                if (repositorioRevista.revistasCadastradas[i] == null) continue;

                else
                {
                    Console.WriteLine(
            "{0, -20} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
              repositorioRevista.revistasCadastradas[i].tituloRevista, repositorioRevista.revistasCadastradas[i].numeroEdicao, repositorioRevista.revistasCadastradas[i].anoPublicacao, repositorioRevista.revistasCadastradas[i].status, repositorioCaixa.caixasCadastradas[i].etiqueta
         );

                }
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
        }

        public void ExcluirRevista()
        {
            VisualizarRevistas();
            Console.WriteLine("Digite o Titulo da revista que deseja excluir");
            string revistaExcluir = Console.ReadLine()!;

            for (int i = 0; i < repositorioRevista.revistasCadastradas.Length; i++)
            {
                if (repositorioRevista.revistasCadastradas[i] == null) continue;

                else if (revistaExcluir == repositorioRevista.revistasCadastradas[i].tituloRevista)
                {
                    repositorioRevista.revistasCadastradas[i] = null;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Revista excluida com sucesso!, Clique ENTER para continuar");
                    Console.ReadLine();
                    Console.ResetColor();
                }
            }
        }
    }
}
