

using ClubeDoLivro.ConsoleApp.ModuloLivro;

namespace ClubeDoLivro.ConsoleApp.ModuloAmigo
{
    public class TelaAmigo
    {
        RepositorioAmigo repositorio = new RepositorioAmigo();
        public RepositorioRevista repositorioRevista;
        public TelaRevista telaRevista;



        public TelaAmigo(TelaRevista telaRevista, RepositorioRevista repositorioRevista)
        {
            this.telaRevista = telaRevista;
            this.repositorioRevista = repositorioRevista;

        }
        public int MenuAmigo()
        {

            int opcao;
            Console.WriteLine("-------------------------");
            Console.WriteLine("Menu Amigos");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Qual a opção que deseja?");
            Console.WriteLine("1 - Cadastrar Novo Amigo");
            Console.WriteLine("2 - Editar Amigo ja existente");
            Console.WriteLine("3 - Excluir  Amigo");
            Console.WriteLine("4 - Emprestar revista a um Amigo");
            Console.WriteLine("5 - Visualizar revistas emprestadas a um Amigo");
            Console.WriteLine("-------------------------");
            opcao = Convert.ToInt32(Console.ReadLine());


            return opcao;
        }

        public void CadastrarNovoAmigo()
        {
            Console.WriteLine("Qual o nome completo do novo amigo?");
            string NomeCompleto = Console.ReadLine()!;

            Console.WriteLine("Qual o nome completo do responsavel do novo amigo?");
            string NomeResponsavel = Console.ReadLine()!;

            Console.WriteLine("Qual o telefone do novo amigo?");
            string Telefone = Console.ReadLine()!;


            Amigo NovoAmigo = new Amigo(NomeCompleto, NomeResponsavel, Telefone);
            repositorio.amigosCadastrados[repositorio.contadorAmigos++] = NovoAmigo;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Amigo Cadastrado com sucesso!, Clique ENTER para continuar");
            Console.ReadLine();
            Console.ResetColor();
        }

        public void EditarAmigo()
        {
            VisualizarAmigos();
            Console.WriteLine("Digite o nome Completo do amigo que deseja editar");
            string nomeVerificacao = Console.ReadLine()!;

            bool amigoExiste = repositorio.EditarAmigo(nomeVerificacao);

            if (amigoExiste == true)
            {
                Console.WriteLine("Qual vai ser o nome do amigo que esta sendo editado?");
                string nomeNovo = Console.ReadLine()!;

                Console.WriteLine("Qual vai ser o nome do responsavel do amigo que esta sendo editado?");
                string nomeResponsavelNovo = Console.ReadLine()!;

                Console.WriteLine("Qual vai ser o telefone do amigo que esta sendo editado?");
                string telefoneNovo = Console.ReadLine()!;

                Amigo AmigoEditado = new Amigo(nomeNovo, nomeResponsavelNovo, telefoneNovo);
                repositorio.amigosCadastrados[repositorio.contadorAmigos++] = AmigoEditado;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Amigo Editado com sucesso!, Clique ENTER para continuar");
                Console.ResetColor();
            }
        }

        public void VisualizarAmigos()
        {
            Console.WriteLine(
            "{0, -25} | {1, -25} | {2, -25}",
         "Nome Completo", "Nome Responsavel", "Telefone"
        );
            for (int i = 0; i < repositorio.amigosCadastrados.Length; i++)
            {
                if (repositorio.amigosCadastrados[i] == null) continue;

                else
                {
                    Console.WriteLine(
            "{0, -25} | {1, -25} | {2, -25} |",
              repositorio.amigosCadastrados[i].nomeCompleto, repositorio.amigosCadastrados[i].nomeResponsavel, repositorio.amigosCadastrados[i].telefone
         );

                }
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
        }

        public void ExcluirAmigo()
        {
            VisualizarAmigos();
            Console.WriteLine("Digite o nome completo do amigo que deseja excluir");
            string amigoExcluir = Console.ReadLine()!;

            for (int i = 0; i < repositorio.amigosCadastrados.Length; i++)
            {
                if (repositorio.amigosCadastrados[i] == null) continue;

                else if (amigoExcluir == repositorio.amigosCadastrados[i].nomeCompleto)
                {
                    repositorio.amigosCadastrados[i] = null;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Amigo excluido com sucesso!, Clique ENTER para continuar");
                    Console.ReadLine();
                    Console.ResetColor();
                }
            }
        }

        public void EmprestarRevistaAmigo()
        {
            bool revistaExiste = false;
            telaRevista.VisualizarRevistas();

            Console.WriteLine("Digite qual o titulo da revista que deseja emprestar");
            string tituloEmprestimo = Console.ReadLine()!;

            for (int i = 0; i < repositorioRevista.revistasCadastradas.Length; i++)
            {
                if (repositorioRevista.revistasCadastradas[i] == null) continue;

                else if (repositorioRevista.revistasCadastradas[i].tituloRevista == tituloEmprestimo) ;
                {
                    revistaExiste = true;
                }
            }

            if (revistaExiste)
            {
                VisualizarAmigos();
                Console.WriteLine("Digite qual o nome  do amigo que deseja emprestar");
                string amigoEmprestimo = Console.ReadLine()!;

                for (int i = 0; i < repositorio.amigosCadastrados.Length; i++)
                {
                    if (repositorio.amigosCadastrados[i] == null) continue;

                    else if (repositorio.amigosCadastrados[i].nomeCompleto == amigoEmprestimo)
                    {
                        repositorio.amigosCadastrados[i].Revistas[i] = tituloEmprestimo;
                    }
                }
            }

            else if (!revistaExiste)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Revista invalida, Clique ENTER para continuar");
                Console.ReadLine();
                Console.ResetColor();
            }
        }

        public void ExibirRevistasCadastradasEmUmAmigo()
        {
            VisualizarAmigos();
            Console.WriteLine("Digite o nome do amigo que deseja visualizar as revistas emprestadas");
            string amigo = Console.ReadLine()!;
            bool amigoExiste = false;

            for (int i = 0; i < repositorio.amigosCadastrados.Length; i++)
            {
                if (repositorio.amigosCadastrados[i] == null) continue;

                else if (repositorio.amigosCadastrados[i].nomeCompleto == amigo)
                {
                    amigoExiste = true;
                }
            }

            if (amigoExiste)
            {
               
                for(int i = 0; i < ; i++)
                {
                    if (repositorio.amigosCadastrados[i] == null) continue;

                    else
                        Console.WriteLine(repositorio.amigosCadastrados[i].Revistas);
                }

                Console.ReadLine();
            }
        }
    }
}
