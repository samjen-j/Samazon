using Microsoft.AspNetCore.Mvc;
using Samazon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samazon.Components
{
    public class CatsViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        public CatsViewComponent (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.CategorySelect = RouteData?.Values["category"];

            var cats = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(cats);
        }
    }
}
