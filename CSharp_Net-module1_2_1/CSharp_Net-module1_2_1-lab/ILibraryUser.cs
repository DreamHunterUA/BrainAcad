using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CSharp_Net_module1_2_1_lab.Model;

namespace CSharp_Net_module1_2_1_lab
{
    interface ILibraryUser
    {
        void AddBook(Book book);
        void RemoveBook(int index);

        string BookInfo(int index);
        int BooksCount();

    }
}
