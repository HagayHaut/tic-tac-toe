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

        private void DisplayBoard()
        {
            Console.WriteLine($" {@board[0]} | {@board[1]} | {@board[2]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {@board[3]} | {@board[4]} | {@board[5]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {@board[6]} | {@board[7]} | {@board[8]} ");
            Console.WriteLine("-----------");
        }

        private int InputToIndex(string input)
        {
            return Int32.Parse(input) - 1;
        }

        private void Move(int index, char token)
        {
            board[index] = token;
            moveCount++;
        }

        private bool PositionTaken(int index)
        {
            return board[index] != ' ';
        }

        private bool IsValidMove(int index)
        {
            return index >= 0 && index < 9 && !PositionTaken(index);
        }

        private char CurrentPlayer()
        {
            return moveCount % 2 == 0 ? 'X' : 'O';
        }

        private void Turn()
        {
            Console.Write("Please enter a position (1-9): ");
            string userInput = Console.ReadLine();
            int index = InputToIndex(userInput);

            if (IsValidMove(index))
            {
                Move(index, CurrentPlayer());
                DisplayBoard();
            }
            else
            {
                Turn();
            }
        }

        // int.MaxValue in first position means isWon is false
        // else returns winning combo
        private (int, int, int) IsWon()
        {
            foreach (var (a, b, c) in winCombos)
            {
                if (PositionTaken(a) && board[a] == board[b] && board[b] == board[c])
                {
                    return (a, b, c);
                }
            }

            return (int.MaxValue, 0, 0);
        }

        private bool IsFull()
        {
            foreach (char c in board)
            {
                if (c == ' ') return false;
            }

            return true;
        }

        private bool IsDraw()
        {
            var (a, b, c) = IsWon();
            return IsFull() && a == int.MaxValue;
        }

        private bool IsOver()
        {
            var (a, b, c) = IsWon();
            return a != int.MaxValue || IsDraw();
        }

        private char Winner()
        {
            var (a, b, c) = IsWon();
            return a == int.MaxValue ? ' ' : board[a];
        }

        public void Play()
        {
            while (!IsOver())
            {
                Turn();
            }

            Console.WriteLine(Winner() == ' ' ? "DRAW! Thanks for playing!" : $"{Winner()} WINS! Thanks for playing!");
        }
    }
}