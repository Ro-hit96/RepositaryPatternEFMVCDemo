using RepositaryPatternEFMVCDemo.Models;
using RepositaryPatternEFMVCDemo.Repositary;

namespace RepositaryPatternEFMVCDemo.Services
{
    public class BookService : IBookService// craete class and Implement Interface
    {
        private readonly IBookRepository repo;//need to inject repository as its dependency

        public BookService(IBookRepository repo)//Create constuctor and pass  IBookRepository repo
        {
            this.repo = repo; 
        }
        public int AddBook(Book book)
        {
            return repo.AddBook(book);
        }

        public int DeleteBook(int id)
        {
           return repo.DeleteBook(id);
        }

        public Book GetBookById(int id)
        {
            return repo.GetBookById(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return repo.GetBooks();
        }

        public int UpdateBook(Book book)
        {
            return repo.UpdateBook(book);
        }
    }
}
