using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookManager bookManager = new BookManager(new List<Book>());

            Book book = new Book { Id = 1, Name = "Çalıkuşu", Author = "Reşat Nuri", Price = 100 };
            Book book2 = new Book { Id = 2, Name = "Kuyucaklı Yusuf", Author = "Sabahattin Ali", Price = 120 };
            Book updatedBook = new Book { Id = 1, Name = "Çalıkuşu", Author = "Reşat Nuri Güntekin", Price = 110 };

            bookManager.AddBook(book);
            bookManager.ListBooks();
            Console.WriteLine("***************");
            bookManager.AddBook(book2);
            bookManager.ListBooks();
            Console.WriteLine("***************");
            bookManager.UpdateBook(updatedBook);
            bookManager.ListBooks();
            Console.WriteLine("***************");
            bookManager.DeleteBook(1);
            bookManager.ListBooks();
            Console.ReadLine();
        }

    }

    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
    }

    public class BookManager : IBook
    {
        private List<Book> _books;

        public BookManager(List<Book> books)
        {
            _books = books;
        }

        public void ListBooks()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("No book available!");
            }

            Console.WriteLine("List of books:");

            foreach (var book in _books)
            {
                Console.WriteLine("{0}-{1}-{2}-{3}", book.Id, book.Name, book.Author, book.Price);
            }
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
            Console.WriteLine("Book added!");
        }

        public void UpdateBook(Book book)
        {
            var updatedBook = _books.FirstOrDefault(m => m.Id == book.Id);

            if (updatedBook != null)
            {
                updatedBook.Name = book.Name;
                updatedBook.Author = book.Author;
                updatedBook.Price = book.Price;


                Console.WriteLine("Book updated!");
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }

        public void DeleteBook(int id)
        {
            var bookToDelete = _books.FirstOrDefault(x => x.Id == id);

            if (bookToDelete != null)
            {
                _books.Remove(bookToDelete);
                Console.WriteLine("Book deleted!");
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }
    }

    public interface IBook
    {
        void ListBooks();
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
