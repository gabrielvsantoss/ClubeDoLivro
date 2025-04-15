

using ClubeDoLivro.ConsoleApp.ModuloRevista;

namespace ClubeDoLivro.ConsoleApp.ModuloAmigo
{
    public class TelaAmigo
    {
        RepositorioAmigo repositorioAmigo;
        public RepositorioRevista repositorioRevista;
        public TelaRevista telaRevista;

        public Amigo amigoValidar = new Amigo("", "", "");


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
            Console.WriteLine("4 - Visualizar  Amigos Cadastrados");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("-------------------------");
            Console.Write("Opção: ");
            opcao = Convert.ToInt32(Console.ReadLine());


            return opcao;
        }

        public void CadastrarNovoAmigo()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Qual o nome completo do novo amigo?");
                string NomeCompleto = Console.ReadLine()!;
                bool nomeExiste = VerificarExistenciaNome(NomeCompleto);
                
                if(nomeExiste)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Este nome ja esta cadastrado no sistema\n Aperte ENTER para tentar novamente");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }

                Console.WriteLine("Qual o nome completo do responsavel do novo amigo?");
                string NomeResponsavel = Console.ReadLine()!;

                Console.WriteLine("Qual o telefone do novo amigo? Utilize o formato: (00 0000 - 0000");
                string Telefone = Console.ReadLine()!;
                bool telefoneExiste = VerificarExistenciaTelefone(Telefone);

                   if (telefoneExiste)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Este telefone ja esta cadastrado no sistema\n Aperte ENTER para tentar novamente");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }

                string erros = amigoValidar.verificarDados(NomeCompleto, NomeResponsavel, Telefone);

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
                    
                    Amigo NovoAmigo = new Amigo(NomeCompleto, NomeResponsavel, Telefone);
                    repositorioAmigo.amigosCadastrados[repositorioAmigo.contadorAmigos++] = NovoAmigo;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Amigo Cadastrado com sucesso!, Clique ENTER para continuar");
                    Console.ReadLine();
                    Console.ResetColor();
                    break;
                }

            }
        }

        public void EditarAmigo()
        { 
            Console.Clear();
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

                Console.WriteLine("Qual vai ser o telefone do amigo que esta sendo editado? Utilize o Formato: (00 0000-0000");
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

        public bool VerificarExistenciaNome(string NomeCompleto)
        {
            bool nomeExiste = false;
           for(int i = 0; i < repositorioAmigo.amigosCadastrados.Length; i++)
            {
                if (repositorioAmigo.amigosCadastrados[i] == null) continue;

                else if (repositorioAmigo.amigosCadastrados[i].nomeCompleto == NomeCompleto)
                {
                    nomeExiste = true;
                }
            }

            return nomeExiste;
        }

        public bool VerificarExistenciaTelefone(string Telefone)
        {

            bool telefoneExiste = false;
            for (int i = 0; i < repositorioAmigo.amigosCadastrados.Length; i++)
            {
                if (repositorioAmigo.amigosCadastrados[i] == null) continue;

                else if (repositorioAmigo.amigosCadastrados[i].telefone == Telefone)
                {
                    telefoneExiste = true;
                }
            }

            return telefoneExiste;
        }




    }
}
