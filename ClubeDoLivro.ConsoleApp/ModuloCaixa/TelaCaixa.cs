using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using ClubeDoLivro.ConsoleApp.ModuloRevista;


namespace ClubeDoLivro.ConsoleApp.ModuloCaixa
{
    public class TelaCaixa
    {
        RepositorioCaixa repositorioCaixa;
        public TelaCaixa(RepositorioCaixa repositorioCaixa)
        {
            this.repositorioCaixa = repositorioCaixa;
        }

        public int MenuCaixa()
        {
            int opcao;
            Console.WriteLine("-------------------------");
            Console.WriteLine("Menu Caixas");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1 - Cadastrar Caixa");
            Console.WriteLine("2 - Editar Caixa");
            Console.WriteLine("3 - Excluir Caixa");
            Console.WriteLine("4 - Visualizar Caixas");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("-------------------------");
            Console.Write("Opção: ");
            opcao = Convert.ToInt32(Console.ReadLine());


            return opcao;
        }

         public void CadastrarCaixa()
        {
            while (true)
            {


                Console.WriteLine("Digite qual a etiqueta da caixa que esta sendo cadastrada");
                string Etiqueta = Console.ReadLine()!;

                bool EtiquetaExiste = VerificarExistenciaEtiqueta(Etiqueta);

                if (EtiquetaExiste)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Esa estiqueta ja esta cadastrada no sistema\n Aperte ENTER para tentar novamente");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }

                else if (!EtiquetaExiste)
                {

                    Console.WriteLine("Digite qual a cor da caixa que esta sendo cadastrada");
                    string Cor = ObterCor();

                    Console.WriteLine("Digite quantidade de dias que as revistas pertencente a essa caixa poderao ser emprestada");
                    int DiasEmprestimo = Convert.ToInt32(Console.ReadLine()!);

                    Caixa caixaNova = new Caixa(Etiqueta, Cor, DiasEmprestimo, repositorioCaixa.revistasCaixa);
                    repositorioCaixa.caixasCadastradas[repositorioCaixa.contadorCaixas++] = caixaNova;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Caixa Cadastrada com sucesso!, Clique ENTER para continuar");
                    Console.ReadLine();
                    Console.ResetColor();
                    break;
                }
            }
        }

        public bool VerificarExistenciaEtiqueta(string Etiqueta)
        {
            bool etiquetaExiste = false;
            for (int i = 0; i < repositorioCaixa.caixasCadastradas.Length; i++)
            {
                if (repositorioCaixa.caixasCadastradas[i] == null) continue;

                else if (repositorioCaixa.caixasCadastradas[i].etiqueta == Etiqueta)
                {
                    etiquetaExiste = true;
                }
            }

            return etiquetaExiste;
        }

        public string ObterCor()
        {
            string cor;

            while (true)
            {

                Console.WriteLine("------------");
                Console.WriteLine("Azul");
                Console.WriteLine("------------");
                Console.WriteLine("Vermelho");
                Console.WriteLine("------------");
                Console.WriteLine("Verde");
                Console.WriteLine("------------");
                Console.WriteLine("Amarelo");
                Console.WriteLine("------------");
                Console.WriteLine("");
                Console.WriteLine("Digite qual das quatro Cores voce deseja");
                cor = Console.ReadLine()!.ToLower()!;

                if (cor != "azul" && cor != "vermelho" && cor != "verde" && cor != "amarelo")
                {
                    Console.WriteLine("A cor digitada é invalida\n Aperte ENTER para tentar novamente");
                    Console.ReadLine();
                }
                else
                {
                    break;

                }
            }

            return cor;

        }

        public  void VisualizarCaixas()
        {
            for(int i = 0; i < repositorioCaixa.caixasCadastradas.Length; i++)
            {
                if (repositorioCaixa.caixasCadastradas[i] == null) continue;

                else
                {
                    Console.WriteLine(
            "{0, -25} | {1, -25 } | {2, -25} |",
         "Etiqueta", "Cor", "Dias de Emprestimo"
        );
                    for (int a = 0; i < repositorioCaixa.caixasCadastradas.Length; i++)
                    {
                        if (repositorioCaixa.caixasCadastradas[i] == null) continue;

                        else
                        {
                            Console.WriteLine(
                    "{0, -25} | {1, -25} | {2, -25} |",
                      repositorioCaixa.caixasCadastradas[i].etiqueta, repositorioCaixa.caixasCadastradas[i].cor, repositorioCaixa.caixasCadastradas[i].diasEmprestimo
                 );

                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                    break;
                    

                }
            }
        }



    }
}
