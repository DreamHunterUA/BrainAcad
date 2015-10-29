using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Cons_Dr_Methods
{
    class Board
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public char Symbol { get; private set; }
        public string Message { get; private set; }


        public Board(int x, int y, int width, int heght, char symbol = '*', string message = "Nan")
        {
            X = x;
            Y = y;
            Width = width;
            Height = heght;
            Symbol = symbol;
            Message = message;


        }

        private bool CheckInputData()
        {
            if (X == 0)
                return false;
            if (Y == 0)
                return false;
            if (Message.Length > (Width - X - 2))
                return false;
            if (Y > Height)
                return false;
            if (X > Width)
                return false;
            return true;
        }

        public void Draw()
        {
            if (CheckInputData())
            {
                //draw board
                Console.Clear();
                //if input data valid draw board
                for (int i = 0; i <= Height; i++)
                {
                    for (int j = 0; j <= Width; j++)
                    {
                        if ((i == 0)||(j==Height)||(i==Width)||(j==0))
                        {
                            Console.SetCursorPosition(i, j);
                            Console.Write(Symbol);
                        }
                        if((i==X) && (j ==Y))
                        {
                            Console.SetCursorPosition(i, j);
                            Console.Write(Message);
                        }

                    }
                }
            }
            else
            //else write invalid message            
            {
                Console.WriteLine("Warning input data invalid!!!!");
            }
        }

    }
}
