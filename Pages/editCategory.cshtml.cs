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
    public class editCategoryModel : PageModel
    {

        private readonly NewsPortalContext _context;

        public editCategoryModel(NewsPortalContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Categories categories { get; set; }
        static int? i = 0;
        public void OnGet(int? id)
        {
            if (id != null)
            {
                i = id;
                categories = (from customer in _context.Categories
                          where customer.CategoriesID == id
                          select customer).SingleOrDefault();
            }
        }

        public ActionResult OnPost()
        {
            var customer = categories;
            if (!ModelState.IsValid)
            {
                return Page(); // return page  
            }
            customer.CategoriesID = Convert.ToInt32(i.ToString());
            var result = _context.Update(customer);
            _context.SaveChanges(); // Saving Data in database  
            return RedirectToPage("allNewsCategory");
        }
    }
}