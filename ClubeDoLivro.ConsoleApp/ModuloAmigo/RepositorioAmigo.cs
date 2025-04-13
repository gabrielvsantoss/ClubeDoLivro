

namespace ClubeDoLivro.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo
    {
        public  Amigo[] amigosCadastrados = new Amigo[100];
        public int contadorAmigos = 0;
        public bool EditarAmigo(string nomeVerificacao)
        {
            bool amigoExiste = false;
            for (int i = 0; i < amigosCadastrados.Length; i++)
            {
                if (amigosCadastrados[i] == null) continue;


                else if(nomeVerificacao == amigosCadastrados[i].nomeCompleto)
                {
                    amigosCadastrados[i] = null;
                    amigoExiste = true;

                }             
            }

            return amigoExiste;
        }
    }


 
}
