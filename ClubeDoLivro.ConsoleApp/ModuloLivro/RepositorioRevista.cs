

namespace ClubeDoLivro.ConsoleApp.ModuloLivro
{
   public class RepositorioRevista
    {
        public Revista[] revistasCadastradas = new Revista[100];
        public int contadorRevistas;

        public bool EditarRevista(string nomeVerificacao)
        {
            bool revistaExiste = false;


            for (int i = 0; i < revistasCadastradas.Length; i++)
            {
                if (revistasCadastradas[i] == null) continue;


                else if (nomeVerificacao == revistasCadastradas[i].tituloRevista)
                {
                    revistasCadastradas[i] = null;
                    revistaExiste = true;
                }
            }

            return revistaExiste;
        }
    }
}
