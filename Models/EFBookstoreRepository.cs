using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samazon.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext Context { get; set; }
        public EFBookstoreRepository (BookstoreContext temp)
        {
            Context = temp;
        }
        public IQueryable<Book> Books => Context.Books;

        public void SaveBook(Book b)
        {
            Context.SaveChanges();
        }

        public void AddBook(Book b)
        {
            Context.Add(b);
            Context.SaveChanges();
        }

        public void DeleteBook(Book b)
        {
            Context.Remove(b);
            Context.SaveChanges();
        }
    }
}
