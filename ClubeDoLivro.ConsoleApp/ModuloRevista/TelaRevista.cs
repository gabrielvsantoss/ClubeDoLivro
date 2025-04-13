

using ClubeDoLivro.ConsoleApp.ModuloAmigo;

namespace ClubeDoLivro.ConsoleApp.ModuloRevista
{
    public class TelaRevista
    {
        RepositorioRevista repositorioRevista;
        public TelaRevista(RepositorioRevista repositorioRevista)
        {
            this.repositorioRevista = repositorioRevista;
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
            Console.WriteLine("4 - Sair");
            Console.WriteLine("-------------------------");
            opcao = Convert.ToInt32(Console.ReadLine());


            return opcao;
        }

       public void CadastrarRevista()
        {
            Console.WriteLine("Qual o titulo da revista que deseja cadastrar");
            string Titulo = Console.ReadLine()!;

            Console.WriteLine("Qual o numero da edição da revista que deseja cadastrar?");
            int NumeroEdicao = Convert.ToInt32(Console.ReadLine()!);

            Console.WriteLine("Qual o ano de publicação da revista que deseja cadastrar?");
            int AnoPublicacao = Convert.ToInt32(Console.ReadLine()!);


            Revista NovaRevista = new Revista(Titulo, NumeroEdicao, AnoPublicacao);

            repositorioRevista.revistasCadastradas[repositorioRevista.contadorRevistas++] = NovaRevista;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Revista Cadastrado com sucesso!, Clique ENTER para continuar");
            Console.ReadLine();
            Console.ResetColor();
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

                Revista RevistaEditada = new Revista(Titulo, NumeroEdicao, AnoPublicacao);
                repositorioRevista.revistasCadastradas[repositorioRevista.contadorRevistas++] = RevistaEditada;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Revista Editada com sucesso!, Clique ENTER para continuar");
                Console.ResetColor();
            }
        }



        public void VisualizarRevistas()
        {
            Console.WriteLine(
            "{0, -25} | {1, -10} | {2, -15}",
         "Titulo", "Numero Edição", "Ano Publicação"
        );
            for (int i = 0; i < repositorioRevista.revistasCadastradas.Length; i++)
            {
                if (repositorioRevista.revistasCadastradas[i] == null) continue;

                else
                {
                    Console.WriteLine(
            "{0, -25} | {1, -10} | {2, -15} |",
              repositorioRevista.revistasCadastradas[i].tituloRevista, repositorioRevista.revistasCadastradas[i].numeroEdicao, repositorioRevista.revistasCadastradas[i].anoPublicacao
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
