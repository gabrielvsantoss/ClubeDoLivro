

using ClubeDoLivro.ConsoleApp.ModuloRevista;

namespace ClubeDoLivro.ConsoleApp.ModuloAmigo
{
    public class TelaAmigo
    {
        RepositorioAmigo repositorioAmigo;
        public RepositorioRevista repositorioRevista;
        public TelaRevista telaRevista;



        public TelaAmigo(TelaRevista telaRevista, RepositorioRevista repositorioRevista, RepositorioAmigo repositorioAmigo)
        {
            this.telaRevista = telaRevista;
            this.repositorioRevista = repositorioRevista;
            this.repositorioAmigo = repositorioAmigo;

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
            Console.WriteLine("4 - Sair");
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
            repositorioAmigo.amigosCadastrados[repositorioAmigo.contadorAmigos++] = NovoAmigo;
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

            bool amigoExiste = repositorioAmigo.EditarAmigo(nomeVerificacao);

            if (amigoExiste == true)
            {
                Console.WriteLine("Qual vai ser o nome do amigo que esta sendo editado?");
                string nomeNovo = Console.ReadLine()!;

                Console.WriteLine("Qual vai ser o nome do responsavel do amigo que esta sendo editado?");
                string nomeResponsavelNovo = Console.ReadLine()!;

                Console.WriteLine("Qual vai ser o telefone do amigo que esta sendo editado?");
                string telefoneNovo = Console.ReadLine()!;

                Amigo AmigoEditado = new Amigo(nomeNovo, nomeResponsavelNovo, telefoneNovo);
                repositorioAmigo.amigosCadastrados[repositorioAmigo.contadorAmigos++] = AmigoEditado;
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

        public void ExcluirAmigo()
        {
            VisualizarAmigos();
            Console.WriteLine("Digite o nome completo do amigo que deseja excluir");
            string amigoExcluir = Console.ReadLine()!;

            for (int i = 0; i < repositorioAmigo.amigosCadastrados.Length; i++)
            {
                if (repositorioAmigo.amigosCadastrados[i] == null) continue;

                else if (amigoExcluir == repositorioAmigo.amigosCadastrados[i].nomeCompleto)
                {
                    repositorioAmigo.amigosCadastrados[i] = null;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Amigo excluido com sucesso!, Clique ENTER para continuar");
                    Console.ReadLine();
                    Console.ResetColor();
                }
            }
        }

        

        
    }
}
