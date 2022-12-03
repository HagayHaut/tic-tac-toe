
namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe ttt = new TicTacToe();
            ttt.PrintWelcomeAndPositions();
            ttt.Play();
        }
    }
}
