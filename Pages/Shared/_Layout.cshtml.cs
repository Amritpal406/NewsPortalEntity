using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsPortal.Data;
using NewsPortal.Model;
using Microsoft.AspNetCore.Http; // Needed for the SetString and GetString extension methods
namespace NewsPortal
{
    public class ldldModel : PageModel
    {

        private readonly NewsPortalContext _context;

        public ldldModel(NewsPortalContext context)
        {
            _context = context;
        }
        [BindProperty]
        public String use { get; set; }
        [BindProperty]
        public String val { get; set; }

        public void OnGet()
        {
            if(HttpContext.Session.GetString("Username")==null)
            {
                val = "none";
            }
            else
            {
                val = "block";
            }
        }
    }
}