using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_Net_module1_2_1_lab.Model;

namespace CSharp_Net_module1_2_1_lab
{
    abstract class Cl
    {
        public string str;
        
    }
    class Program
    {
        static void Main(string[] args)
        {                    
            // 8) declare 2 objects. Use default and paremeter constructors
            var user1 = new LibraryUser();
            var user2 = new LibraryUser("User2 First Name", "User2 Last Name", "+380500000000", 20, 1);
            // 9) do operations with books for all users: run all methods for both objects
            user1.AddBook(new Book()
            {
                Author = "Andrew Troelsen",
                Name = "Pro C# 5.0 and the .NET 4.5 Framework (Expert's Voice in .NET) 6th ed. 2012 Edition",
                Year = 2012,
                PublishingHouse = "Apres",
                PageCount = 1463

            });
            user1.AddBook(new Book()
            {
                Author = "Jeffrey Richter",
                Name = "CLR via C# (4th Edition) (Developer Reference) 4th Edition",
                Year = 2013,
                PublishingHouse = "Microsoft Press",
                PageCount = 823

            });
            foreach (var book in user1.BookList)
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine("user1 book info {0}",user1.BookInfo(1));
            Console.WriteLine("user1 book info {0}",user1.BookInfo(10));
            Console.WriteLine("user2 book info {0}", user1.BookInfo(0));
            Console.WriteLine("user2 book info {0}", user1.BookInfo(10));
            user2.AddBook(new Book()
            {
                Author = "Jeffrey Richter",
                Name = "CLR via C# (4th Edition) (Developer Reference) 4th Edition",
                Year = 2013,
                PublishingHouse = "Microsoft Press",
                PageCount = 823

            });
            user2.AddBook(new Book()
            {
                Author = "Andrew Troelsen",
                Name = "Pro C# 5.0 and the .NET 4.5 Framework (Expert's Voice in .NET) 6th ed. 2012 Edition",
                Year = 2012,
                PublishingHouse = "Apres",
                PageCount = 1463

            });
            foreach (var book in user2.BookList)
            {
                Console.WriteLine(book.ToString());
            }




            Console.WriteLine("user1 books count - {0}",user1.BooksCount());
            Console.WriteLine("user2 books count - {0}", user2.BooksCount());
            user1.RemoveBook(0);
            user2.RemoveBook(1);          

            Console.WriteLine("user1 books count - {0}", user1.BooksCount());
            Console.WriteLine("user2 books count - {0}", user2.BooksCount());
            foreach (var book in user1.BookList)
            {
                Console.WriteLine(book.ToString());
            }

            foreach (var book in user2.BookList)
            {
                Console.WriteLine(book.ToString());
            }
            Console.ReadKey();

            

        }
    }
}
