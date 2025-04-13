

namespace ClubeDoLivro.ConsoleApp.ModuloCompartilhado
{
    class TelaCompartilhada
    {
        public int MenuPrincipal()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Digite a opção que deseja");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1 - Menu Amigos");
            Console.WriteLine("2 - Menu Revistas");
            Console.WriteLine("-------------------------------");
            int opcao = Convert.ToInt32(Console.ReadLine());
            return opcao;
        }
    }
}
