using System;

namespace JogoDaForca
{   //Operação ternária = condição ? expressao_true : expressao_false;
    // Se a condição for verdeira, retorna o primeiro valor, caso contrário o segundo.

    //Passos do exercício
    //1 - Registrar os nomes das frutas e fazer o computador gerar uma aleatória. 
    //1.5 - Deixar o código do desenho da forca pronto. 
    //2 - Mostrar para o usuário os espaços em branco da palavra. 
    //3 - Comparar a letra imputada pelo usuário e a gerada pelo computador. 
    //4 - Colocar a quantidade de erros de acordo com as letras imputadas. 
    //5 - Finalizar com uma mensagem de derrota ou vitória.

    internal class Program
    {
        
        static string[] frutaAleatoria = new string[30] { "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "ABACATE", "BACABA", "BACURI", "BANANA", "CAJÁ", "CAJÚ", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA" };

        //static string salGrosso;
        static bool acertou = false, perdeu = false;
        static void Main(string[] args)
        {
            char[] palavraMisteriosa;
            char[] letrasCorretas;
            int palavraGerada;
            int quantidadeErros = 0;
            #region Gera a Palavra aleatória
            Random palavraAleatoria = new Random();
            palavraGerada = palavraAleatoria.Next(1, 30);
            palavraMisteriosa = frutaAleatoria[palavraGerada].ToCharArray();
            
            #endregion

            #region Gera os espaços em branco
            letrasCorretas = new char[palavraMisteriosa.Length];
            for(int i = 0; i < letrasCorretas.Length; i++)
            {
                letrasCorretas[i] = '_';
            }
            #endregion
            
            do //Em uma repeti~ção, todos os valores devem meio que voltar ao início.
            {
                char palpiteJogador;
                bool letraEncontrada = false; // O erro do código quando o jogador errava a letra era que letra encontrada = true e não recebia false novamente. 
                Console.Clear();
                Console.WriteLine("---------------------");
                Console.WriteLine("--- Tema: FRUTAS  ---");
                Console.WriteLine(" -----------         ");
                Console.WriteLine(" |         |         ");
                Console.WriteLine(" |         {0}       ", (quantidadeErros >= 1 ? "o" : " "));
                Console.WriteLine(" |       {0}{1}{2}   ", (quantidadeErros >= 3 ? "/" : " "), (quantidadeErros >= 2 ? " x " : " "), (quantidadeErros >= 3 ? "\\" : " "));
                Console.WriteLine(" |        {0}        ", (quantidadeErros >= 2 ? " x " : " "));
                Console.WriteLine(" |        {0}        ", (quantidadeErros >= 4 ? "/ \\" : " "));
                Console.WriteLine(" |                   ");
                Console.WriteLine(" |                   ");
                Console.WriteLine("_|_____              \t\t");

                Console.Write("\t");
                foreach (char valor in letrasCorretas)
                {
                    Console.Write(valor + " ");
                }

                Console.WriteLine("\n");
                Console.WriteLine("Digite um palpite: ");
                palpiteJogador = Convert.ToChar(Console.ReadLine().ToUpper());

                for (int j = 0; j < palavraMisteriosa.Length; j++)
                {
                    if (palavraMisteriosa[j] == palpiteJogador)
                    {
                        letrasCorretas[j] = palpiteJogador;
                        letraEncontrada = true;
                    }
                    
                }
                if (letraEncontrada == false)
                {
                    quantidadeErros++;
                }
                if (quantidadeErros > 4)
                {
                    perdeu = true;
                    Console.WriteLine("Você perdeu! ");
                }

                string verificarPalavraGerada = new string(palavraMisteriosa);
                string verificarPalavraJogador = new string(letrasCorretas);
                
                if(verificarPalavraGerada == verificarPalavraJogador)
                {
                    acertou = true;
                }

                if (acertou == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Você venceu, nerdola! Parabéns!");
                    Console.WriteLine("A palavra era " + verificarPalavraJogador);
                }
                Console.ReadLine();
            } while (acertou == false && perdeu == false);
        }
    }
}