using RepositaryPatternEFMVCDemo.Data;
using RepositaryPatternEFMVCDemo.Models;

namespace RepositaryPatternEFMVCDemo.Repositary
{
    public class BookRepository : IBookRepository
    {
        ApplicationDbContext db;

        public BookRepository(ApplicationDbContext db)//DI pattern inject dependency in constructor
        {
            this.db = db;      
        }
        public int AddBook(Book book)
        {
            // added the book object in the DBSet
            db.Books.Add(book);
            // SaveChages() reflect the changes from Dbset to DB
            int result = db.SaveChanges();
            return result;
        }

        public int DeleteBook(int id)
        {
            int res = 0;
            var result = db.Books.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                db.Books.Remove(result); // remove from DbSet
                res = db.SaveChanges();
            }
            return res;
        }

        public Book GetBookById(int id)
        {
            var result = db.Books.Where(x => x.Id == id).SingleOrDefault();
            return result;

            //LINQ
            //var res = from b in db.Books
            //          where b.Id == id
            //          select b;
        }

        public IEnumerable<Book> GetBooks()
        {
            // LINQ
            //var result = from b in db.Books
            //             select b;

            //return result;

            // Lambda
            return db.Books.ToList();
        }

        public int UpdateBook(Book book)
        {
            int res = 0;
            // find the record from Dbset that we need to modify
            //var result = (from b in db.Books
            //             where b.Id == book.Id
            //             select b).FirstOrDefault();

            var result = db.Books.Where(x => x.Id == book.Id).FirstOrDefault();

            if (result != null)
            {
                result.Name = book.Name; // book contains new data, result contains old data
                result.Author = book.Author;
                result.Price = book.Price;

                res = db.SaveChanges();// update those changes in DB
            }
            return res;
        }
    }

}
