using System;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************************************************\n");
            PrintWelcomeAndPositions();
            TicTacToe ttt = new TicTacToe();
            ttt.Play();
        }

        static void PrintWelcomeAndPositions()
        {
            Console.WriteLine(" ____  ____  ___    ____   __    ___    ____  _____  ____ ");
            Console.WriteLine("(_  _)(_  _)/ __)  (_  _) /__\\  / __)  (_  _)(  _  )( ___)");
            Console.WriteLine("  )(   _)(_( (__     )(  /(__)\\( (__     )(   )(_)(  )__) ");
            Console.WriteLine(" (__) (____)\\___)   (__)(__)(__)\\___)   (__) (_____)(____)\n");
            Console.WriteLine("\nGrid Positions:");
            Console.WriteLine("\n    1 | 2 | 3 ");
            Console.WriteLine("   -----------");
            Console.WriteLine("    4 | 5 | 6 ");
            Console.WriteLine("   -----------");
            Console.WriteLine("    7 | 8 | 9 \n");
        }
    }
}
