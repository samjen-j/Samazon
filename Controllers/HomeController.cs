using Microsoft.AspNetCore.Mvc;
using Samazon.Models;
using Samazon.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samazon.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository Repo;
        
        public HomeController (IBookstoreRepository temp)
        {
            Repo = temp;
        }
    
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = Repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = Repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum,
                }

            };

            return View(x);
        }
    }
}
