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
            Console.WriteLine(" ------------------------- ");
            Console.WriteLine("|      Menu Caixas        |");
            Console.WriteLine("|-------------------------|");
            Console.WriteLine("|[1] - Cadastrar Caixa    |");
            Console.WriteLine("|[2] - Visualizar Caixas  |");
            Console.WriteLine("|[3] - Sair               |");
            Console.WriteLine(" ------------------------- ");
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
                    Console.ForegroundColor = ConsoleColor.DarkRed;
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
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Caixa Cadastrada com sucesso!, Clique ENTER para continuar");
                    Console.ReadLine();
                    Console.ResetColor();
                    break;
                }
            }
        }

        public void EditarCaixa()
        {

        }

        public void ExcluirCaixa()
        {

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
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("       ------------ ");
                Console.WriteLine("      |    Azul    |");
                Console.WriteLine("       ------------ ");
                Console.ResetColor();

                Console.WriteLine("");

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("       ------------ ");
                Console.WriteLine("      |  Vermelho  |");
                Console.WriteLine("       ------------ ");
                Console.ResetColor();

                Console.WriteLine("");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("       ------------ ");
                Console.WriteLine("      |    Verde   |");
                Console.WriteLine("       ------------ ");
                Console.ResetColor();

                Console.WriteLine("");

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("       ------------ ");
                Console.WriteLine("      |    Ciano   |");
                Console.WriteLine("       ------------ ");
                Console.ResetColor();

                Console.WriteLine("");

                Console.WriteLine("Digite qual das quatro Cores voce deseja");
                cor = Console.ReadLine()!.ToLower()!;

                if (cor != "azul" && cor != "vermelho" && cor != "verde" && cor != "ciano")
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
