using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_Net_module1_2_1_lab.Model;

namespace CSharp_Net_module1_2_1_lab
{
    // 1) declare interface ILibraryUser
    // declare method's signature for methods of class LibraryUser


    // 2) declare class LibraryUser, it implements ILibraryUser
    internal class LibraryUser : ILibraryUser
    {
        // 3) declare properties: FirstName (read only), LastName (read only), 
        // Id (read only), Phone (get and set), BookLimit (read only)

        private string _firstName;
        private string _lastName;
        private int _id;
        private string _phone;
        private int _bookLimit;

        public string FirstName
        {
            get { return _firstName; }
        }

        public string LastName
        {
            get { return _lastName; }
        }

        public int ID
        {
            get { return _id; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private static readonly Random getrandom = new Random();
        private int _booksCount;

        public int BookLimit
        {
            get { return _bookLimit; }
        }

        public Book?[] BookList
        {
            get { return bookList; }
        }

        // 4) declare field (bookList) as a string array
        private Book?[] bookList;
        // 5) declare indexer BookList for array bookList
        public Book? this[int index]
        {
            get
            {
                if ((index < bookList.Length) && (bookList[index] != null))
                    return bookList[index];
                return null;
            }
        }

        // 6) declare constructors: default and parameter
        public LibraryUser()
        {
            _firstName = "First Name";
            _lastName = "Last Name";
            _phone = "+380670000000";
            _bookLimit = 10;
            _id = getrandom.Next(1, int.MaxValue);
            bookList = new Book?[_bookLimit];
            _booksCount = 0;
        }

        public LibraryUser(string firstName, string lastName, string phone, int bookLimit, int id) : this()
        {
            _firstName = firstName;
            _lastName = lastName;
            _phone = phone;
            _bookLimit = bookLimit;
            _id = id;
            bookList = new Book?[_bookLimit];
        }


        // 7) declare methods:                                            

        //AddBook() – add new book to array bookList,
        public void AddBook(Book book)
        {
            if (_booksCount == _bookLimit)
            {
                Console.WriteLine("Your book limit is over.");
                return;
            }
            for (var i = 0; i < bookList.Length; i++)
            {
                if (bookList[i] != null) continue;
                bookList[i] = book;
                _booksCount++;
                return;
            }
        }

        //RemoveBook() – remove book from array bookList,
        public void RemoveBook(int index)
        {
            if (index <= _bookLimit)
            {
                bookList[index] = null;
                _booksCount--;
            }
        }

        //BookInfo() – returns book info by index,
        public string BookInfo(int index)
        {
            return ((index <_bookLimit) && (bookList[index] != null))
                ? this[index].ToString()
                : string.Format("Book with index {0} not found", index);
        }

        //BooksCout() – returns current count of books
        public int BooksCount()
        {
            return _booksCount;
        }
    }
}