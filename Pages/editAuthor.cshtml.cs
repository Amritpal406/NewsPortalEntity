using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Model;
using Microsoft.AspNetCore.Http;

namespace NewsPortal.Pages
{
    public class editAuthorModel : PageModel
    {

        private readonly NewsPortalContext _context;

        public editAuthorModel(NewsPortalContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Author author { get; set; }
        static int? i = 8;
        public void OnGet(int? id)
        {
            if (id != null)
            {
                i = id;
                author = (from customer in _context.Author
                        where customer.AuthorID == id
                        select customer).SingleOrDefault();
            }
        }

        public ActionResult OnPost()
        {
            var customer = author;
            if (!ModelState.IsValid)
            {
                return Page(); // return page  
            }
            customer.AuthorID = Convert.ToInt32(i.ToString());
            var result = _context.Update(customer);
            _context.SaveChanges(); // Saving Data in database  
            return RedirectToPage("allAuthor");
        }
    }
}