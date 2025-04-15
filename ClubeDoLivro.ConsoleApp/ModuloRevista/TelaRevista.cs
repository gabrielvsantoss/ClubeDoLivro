

using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using ClubeDoLivro.ConsoleApp.ModuloCaixa;
using System.Runtime.Serialization;
namespace ClubeDoLivro.ConsoleApp.ModuloRevista
{
    public class TelaRevista
    {
        RepositorioRevista repositorioRevista;
        Revista revistaVerificacao = new Revista("",1,default,"");
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
            Console.WriteLine(" ---------------------------------------");
            Console.WriteLine("|             Menu Revistas             |");
            Console.WriteLine("|---------------------------------------|");
            Console.WriteLine("|[1] - Cadastrar Nova Revista           |");
            Console.WriteLine("|[2] - Editar Revista ja existente      |");
            Console.WriteLine("|[3] - Excluir  Revista                 |");
            Console.WriteLine("|[4] - Visualizar  Revistas Cadastradas |");
            Console.WriteLine("|[5] - Sair                             |");
            Console.WriteLine(" --------------------------------------- ");
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
                bool revistaExiste = VerificarExistenciaTitulo(Titulo);
                while (true)
                {


                    if (revistaExiste)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Esta reviista ja esta cadastrada no sistema\n Aperte ENTER para tentar novamente");
                        Console.ResetColor();
                        Console.ReadLine();
                        continue;
                    }

                    else if (!revistaExiste)
                    {
                        Console.WriteLine("Qual o numero da edição da revista que deseja cadastrar?");
                        int NumeroEdicao = Convert.ToInt32(Console.ReadLine()!);

                        Console.WriteLine("Qual o ano de publicação da revista que deseja cadastrar? (dd/mm/yyyy)");
                        DateTime AnoPublicacao = Convert.ToDateTime((Console.ReadLine()!));


                        Console.WriteLine();
                        string erros = revistaVerificacao.ValidarDados(Titulo, NumeroEdicao, AnoPublicacao);


                        if (erros.Length > 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
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

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Revista Cadastrado com sucesso!, Clique ENTER para continuar");
                            Console.ReadLine();
                            Console.ResetColor();
                            return;
                        }
                        return;
                }
                    


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
                Console.WriteLine("Qual é o nome da revista que esta sendo editada?");
                string Titulo = Console.ReadLine()!;

                Console.WriteLine("Qual é o numero de edição da revista que esta sendo editada?");
                int NumeroEdicao = Convert.ToInt32(Console.ReadLine()!);

                Console.WriteLine("Qual é o ano de publicação da revista  que esta sendo editada?");
                DateTime AnoPublicacao = Convert.ToDateTime((Console.ReadLine()!));

                Revista RevistaEditada = new Revista(Titulo, NumeroEdicao, AnoPublicacao, "");
                repositorioRevista.revistasCadastradas[repositorioRevista.contadorRevistas++] = RevistaEditada;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Revista Editada com sucesso!, Clique ENTER para continuar");
                Console.ResetColor();
            }
        }



        public void VisualizarRevistas()
        {
            Console.WriteLine(
            "{0, -20} | {1, -20} | {2, -20}",
         "Titulo", "Numero Edição", "Ano Publicação", "Status"
        );
            for (int i = 0; i < repositorioRevista.revistasCadastradas.Length; i++)
            {
                if (repositorioRevista.revistasCadastradas[i] == null) continue;

                else
                {
                    Console.WriteLine(
            "{0, -20} | {1, -20} | {2, -20} | {3, -20}",
              repositorioRevista.revistasCadastradas[i].tituloRevista, repositorioRevista.revistasCadastradas[i].numeroEdicao, repositorioRevista.revistasCadastradas[i].anoPublicacao.ToShortDateString(), repositorioRevista.revistasCadastradas[i].status
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

        public bool VerificarExistenciaTitulo(string Titulo)
        {
            bool revistaExiste = false;
            for (int i = 0; i < repositorioRevista.revistasCadastradas.Length; i++)
            {
                if (repositorioRevista.revistasCadastradas[i] == null) continue;

                else if (repositorioRevista.revistasCadastradas[i].tituloRevista == Titulo)
                {
                    revistaExiste = true;
                }
            }

            return revistaExiste;
        }
    }
}
