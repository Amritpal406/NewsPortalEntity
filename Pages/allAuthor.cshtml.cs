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
    public class allAuthorModel : PageModel
    {


        private readonly NewsPortalContext _context;

        public allAuthorModel(NewsPortalContext context)
        {
            _context = context;
        }
        public List<Author> AuthorList { get; set; }

        public void OnGet()
        {
            var data = (from customerList in _context.Author select customerList).ToList();
            AuthorList = data;
        }

        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from customer in _context.Author
                            where customer.AuthorID == id
                            select customer).SingleOrDefault();
                _context.Remove(data);
                _context.SaveChanges();
            }
            return RedirectToPage("allAuthor");
        }
    }
}