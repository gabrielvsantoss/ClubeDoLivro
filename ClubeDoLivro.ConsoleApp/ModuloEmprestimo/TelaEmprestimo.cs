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
       public Revista revista = new Revista(" ", 0, 0);
        public TelaEmprestimo(RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista, TelaRevista telaRevista, TelaAmigo telaAmigo)
        {
            this.repositorioAmigo = repositorioAmigo;
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
            Console.WriteLine("-------------------------");
            opcao = Convert.ToInt32(Console.ReadLine());


            return opcao;
        }

        public void CadastrarEmprestimo()
        {
            
                telaRevista.VisualizarRevistas();

                Console.WriteLine("Qual revista que voce deseja emprestar");
                string revistaEmprestimo = Console.ReadLine()!;
                bool revistaEncontrada = false;
                
                
                for(int i = 0; i < repositorioRevista.revistasCadastradas.Length; i++)
                {
                     if (repositorioRevista.revistasCadastradas[i] == null) continue;

                    else if (repositorioRevista.revistasCadastradas[i].tituloRevista == revistaEmprestimo)
                    {
                        revista = repositorioRevista.revistasCadastradas[i];
                        revistaEncontrada = true;
                    }
                }

                    Console.WriteLine("-----------------------");

                if (!revistaEncontrada)
                {
                    
                }
                else if(revistaEncontrada)
                {
                     telaAmigo.VisualizarAmigos();
                    Console.WriteLine("Qual o nome do amigo que deseja emprestar?");
                    string  amigoEmprestimo = Console.ReadLine()!;
                    
                    for(int i = 0; i < repositorioAmigo.amigosCadastrados.Length; i++)
                    {
                        if (repositorioAmigo.amigosCadastrados[i] == null) continue;

                        else if (repositorioAmigo.amigosCadastrados[i].nomeCompleto == amigoEmprestimo)
                        {
                            repositorioAmigo.amigosCadastrados[i].revistasCadastradasEmUmAmigo[repositorioAmigo.amigosCadastrados[i].quantidadeDeRevistasCadastradasEmUmAmigo++] = revista;
                        }
                    }
                }
        }
       
        public void visualizarEmprestimos()
        {
            telaAmigo.VisualizarAmigos();
            Console.WriteLine("Digite o nome do amigo que deseja visualizar os emprestimos");
            string amigoVisualizado = Console.ReadLine()!;

            for(int i = 0 ; i < repositorioAmigo.amigosCadastrados.Length; i ++)
            {
                if (repositorioAmigo.amigosCadastrados[i] == null) continue;

                else if (repositorioAmigo.amigosCadastrados[i].nomeCompleto == amigoVisualizado)
                {
                    Console.WriteLine(
                      "{0, -25} | {1, -10} | {2, -15}",
                   "Titulo", "Numero Edição", "Ano Publicação"
                  );

                   for(int a = 0; a < repositorioAmigo.amigosCadastrados[a].revistasCadastradasEmUmAmigo.Length; a++)
                    {
                        Console.WriteLine(
            "{0, -25} | {1, -10} | {2, -15} |",
            repositorioAmigo.amigosCadastrados[a].revistasCadastradasEmUmAmigo[a].tituloRevista, repositorioAmigo.amigosCadastrados[a].revistasCadastradasEmUmAmigo[a].numeroEdicao, repositorioAmigo.amigosCadastrados[a].revistasCadastradasEmUmAmigo[a].anoPublicacao
         );
                    }
                }

            }
        }

    }
}
