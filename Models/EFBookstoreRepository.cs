﻿using System;
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
    }
}
