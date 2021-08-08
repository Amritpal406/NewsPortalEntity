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
    public class AuthorsModel : PageModel
    {

        private readonly NewsPortalContext _context;

        public AuthorsModel(NewsPortalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Author author { get; set; }

        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            var customer = author;
            if (!ModelState.IsValid)
            {
                return Page(); // return page  
            }
            customer.AuthorID = 0;
            var result = _context.Add(customer);
            _context.SaveChanges(); // Saving Data in database  
            return RedirectToPage("allAuthor");
        }
    }
}
