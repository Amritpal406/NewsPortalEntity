using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; // Needed for the SetString and GetString extension methods
using NewsPortal.Data;
using NewsPortal.Model;

namespace NewsPortal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly NewsPortalContext _context;
        public IndexModel(NewsPortalContext context)
        {
            _context = context;
        }
        public List<News> CustomerList { get; set; }
        public void OnGet()
        {
            var data = (from customerlist in _context.News
                        select customerlist).ToList();
            CustomerList = data;
        }
    }
}