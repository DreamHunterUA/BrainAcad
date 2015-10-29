using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Cons_Dr_Methods
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the width of the board");

            int width;
            while (!Int32.TryParse(Console.ReadLine(), out width))
            {
                Console.WriteLine("Please enter a valid width value");  
            }
                    
            Console.WriteLine("Enter the height of the board");
            int height;
            while (!Int32.TryParse(Console.ReadLine(), out height))
            {
                Console.WriteLine("Please enter a valid height value");
            }
               
            Console.WriteLine("Enter the symbol of the board");
            var symbol = Console.ReadLine();
            if ((Convert.ToChar(symbol)!='*')||(Convert.ToChar(symbol) != '+')|| (Convert.ToChar(symbol) != '.'))
            {
                symbol = "*";
            }
            Console.WriteLine("Enter left position of the message");
            int x;
            while (!Int32.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Please enter a valid left position value");
            }
            
            Console.WriteLine("Enter top position of the message");
            int y;
            while (!Int32.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Please enter a valid top position value");
            }
            Console.WriteLine("Enter message your want to print");
            var message = Console.ReadLine();

            var board = new Board(x, y, width, height, Convert.ToChar(symbol), message);
            //var board = new Board(1, 3, 10, 10);
            board.Draw();
            Console.WriteLine("\n");
            Console.WriteLine("Press any key...");

            Console.ReadLine();


        }
    }
}
