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
    public class EditNewsModel : PageModel
    {

        private readonly NewsPortalContext _context;

        public EditNewsModel(NewsPortalContext context)
        {
            _context = context;
        }
        [BindProperty]
        public News news { get; set; }
         static int? i = 8;
        [BindProperty]
        public List<Categories> Category { get; set; }
        [BindProperty]
        public List<Author> AuthorList { get; set; }

        public void OnGet(int? id)
        {
              var data = (from customerList in _context.Categories select customerList).ToList();
            Category = data;
            var data1 = (from customerList in _context.Author select customerList).ToList();
            AuthorList = data1;
            if (id != null)
            {
                i =id;
                   news = (from customer in _context.News
                            where customer.NewsID == id
                            select customer).SingleOrDefault();
            }
        }

        public ActionResult OnPost()
        {
            var customer = news;
            if (!ModelState.IsValid)
            {
                return Page(); // return page  
            }
            customer.NewsID =Convert.ToInt32(i.ToString());
            var result = _context.Update(customer);
            _context.SaveChanges(); // Saving Data in database  
         return RedirectToPage("allNews");
        }
    }
}
