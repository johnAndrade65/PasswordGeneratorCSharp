using System;
using System.Threading;

namespace PasswordGenerator
{
    class Program
    {
        static void Main()
        {
            //Método Main() limpa o console e chama o método Menu()
            Console.Clear();
            Menu();
        }

        static void Menu()
        {
            //Inicialmente o método Menu() irá exibir o menu do programa
            Console.WriteLine("Olá, bem vindo(a) ao Password Generator.");
            Console.WriteLine("Com qual número de caracteres você deseja gerar a sua senha?:");

            //Em seguida irá pegar o tamanho desejado pelo usuario para gerar a futura senha
            int passwordSize = int.Parse(Console.ReadLine());
            Console.WriteLine($"\nO número de caracteres escolhido foi: {passwordSize}");

            //Por terceiro o método Menu() irá chamar o método GeneratePassword() com a variavel "passwordSize" como parâmetro
            string password = GeneratePassword(passwordSize);
            Console.WriteLine($"\nSua senha é: {password}\n");

            //Menu que irá aparecer após a senha gerada
            Console.WriteLine("Escolha uma opção abaixo:");
            Console.WriteLine("1 - Gerar outra senha.");
            Console.WriteLine("0 - Encerrar programa.");
            int Options = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            
            //O switch vai servir para chamar o método de acordo com o valor desejado pelo usuario
            switch (Options)
            {
                case 1:
                    Menu();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
            }
        }

        static string GeneratePassword(int PasswordSize)
        {
            //No inicio do método GeneratePassword() teremos as váriaveis
            const string charactersAllowed = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var password = new char[PasswordSize];

            //Por segundo ele(O método) irá chamar o método Loading()
            Loading();

            //Por terceiro teremos um laço "for" irá gerar a senha usando o "random" e os caracteres permitidos
            for (int i = 0; i < PasswordSize; i++)
            {
                password[i] = charactersAllowed[random.Next(charactersAllowed.Length)];
            }

            /*Por último esse trecho do código" cria uma nova string a partir
            do array de caracteres chamado "password" e retorna essa nova string.*/
            return new string(password);
        }
        static void Loading()
        {
            //O método Loading() irá criar uma animação de carregamento para melhorar o visual do nosso sistema
            Console.Write("Gerando senha.");

            //Esse laço irá gerar um "." a cada 0,2 segundos
            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }

            //Por fim irá mostrar um conclúido e irá dar uma pausa de 0,3 segundos
            Console.Write("Concluído!.\n");
            Thread.Sleep(300);
        }
    }
}
