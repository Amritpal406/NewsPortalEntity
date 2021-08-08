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
    public class allNewsModel : PageModel
    {


         private readonly NewsPortalContext _context;

        public allNewsModel(NewsPortalContext context)
        {
            _context = context;
        }


        public List<News> CustomerList { get; set; }

        public void OnGet()
        {
            var data = (from customerList in _context.News select customerList).ToList();
            CustomerList = data;
        }

        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from customer in _context.News
                            where customer.NewsID== id
                            select customer).SingleOrDefault();
                _context.Remove(data);
                _context.SaveChanges();
            }
            return RedirectToPage("allNews");
        }
    }
}