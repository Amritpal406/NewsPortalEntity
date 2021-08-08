using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsPortal.Data;
using NewsPortal.Model;

namespace NewsPortal.Pages
{
    public class allNewsCategory : PageModel
    {


        private readonly NewsPortalContext _context;

        public allNewsCategory(NewsPortalContext context)
        {
            _context = context;
        }
        public List<Categories> CategoriesList { get; set; }

        public void OnGet()
        {
            var data = (from customerList in _context.Categories select customerList).ToList();
            CategoriesList = data;
        }

        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from customer in _context.Categories
                            where customer.CategoriesID == id
                            select customer).SingleOrDefault();
                _context.Remove(data);
                _context.SaveChanges();
            }
            return RedirectToPage("allNewsCategory");
        }
    }
}