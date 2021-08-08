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
    public class NewsModel : PageModel
    {
        private readonly NewsPortalContext _context;
        public NewsModel(NewsPortalContext context)
        {
            _context = context;
        }
        [BindProperty]
        public List<Categories> Category { get; set; }
        [BindProperty]
        public List<Author> AuthorList { get; set; }
        [BindProperty]
        public News news { get; set; }

        public void OnGet()
        {
            var data = (from customerList in _context.Categories select customerList).ToList();
            Category = data;
            var data1 = (from customerList in _context.Author select customerList).ToList();
            AuthorList = data1;
        }

        public ActionResult OnPost()
        {
            var customer = news;
            if (!ModelState.IsValid)
            {
                return Page(); // return page  
            }
            customer.NewsID = 0;
            var result = _context.Add(customer);
            _context.SaveChanges(); // Saving Data in database  
            return RedirectToPage("allNews");
        }
        }
}
