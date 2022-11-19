using System;
using System.Collections.Generic;

namespace TicTacToeGame
{
    public class TicTacToe
    {
        char[] board;
        int moveCount;
        (int, int, int)[] winCombos = new (int, int, int)[] {
            (0, 1, 2),
            (3, 4, 5),
            (6, 7, 8),
            (0, 3, 6),
            (1, 4, 7),
            (2, 5, 8),
            (0, 4, 8),
            (2, 4, 6)
        };

        public TicTacToe()
        {
            board = Enumerable.Repeat(' ', 9).ToArray();
            moveCount = 0;
        }

        private void displayBoard()
        {
            Console.WriteLine($" {@board[0]} | {@board[1]} | {@board[2]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {@board[3]} | {@board[4]} | {@board[5]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {@board[6]} | {@board[7]} | {@board[8]} ");
            Console.WriteLine("-----------");
        }

        private int inputToIndex(string input)
        {
            return Int32.Parse(input) - 1;
        }

        private void move(int index, char token)
        {
            board[index] = token;
            moveCount++;
        }

        private bool positionTaken(int index)
        {
            return board[index] != ' ';
        }

        private bool isValidMove(int index)
        {
            return !positionTaken(index) && index >= 0 && index < 9;
        }

        private char currentPlayer()
        {
            return moveCount % 2 == 0 ? 'X' : 'O';
        }

        private void turn()
        {
            Console.Write("Please enter a position (1-9): ");
            string userInput = Console.ReadLine();
            int index = inputToIndex(userInput);

            if (isValidMove(index))
            {
                move(index, currentPlayer());
            }
            else
            {
                turn();
            }
            displayBoard();
        }

        // int.MaxValue in first position means isWon is false
        // else returns winning combo
        private (int, int, int) isWon()
        {
            foreach (var (a, b, c) in winCombos)
            {
                if (positionTaken(a) && board[a] == board[b] && board[b] == board[c])
                {
                    return (a, b, c);
                }
            }

            return (int.MaxValue, 0, 0);
        }

        private bool isFull()
        {
            foreach (char c in board)
            {
                if (c == ' ') return false;
            }

            return true;
        }

        private bool isDraw()
        {
            var (a, b, c) = isWon();
            return isFull() && a == int.MaxValue;
        }

        private bool isOver()
        {
            var (a, b, c) = isWon();
            return a != int.MaxValue || isDraw();
        }

        private char winner()
        {
            var (a, b, c) = isWon();
            return a == int.MaxValue ? ' ' : board[a];
        }

        public void play()
        {
            while (!isOver())
            {
                turn();
            }

            Console.WriteLine(winner() == ' ' ? "DRAW! Thanks for playing!" : $"{winner()} WINS! Thanks for playing!");
        }
    }
}