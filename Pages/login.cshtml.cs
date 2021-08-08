using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NewsPortal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NewsPortal.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public String login { get; set; }

        [BindProperty]
        public String Username { get; set; }
        [BindProperty]
        public String Password { get; set; }

        private readonly NewsPortalContext _context;

        public LoginModel(NewsPortalContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            login = "false";
            if (!(HttpContext.Session.GetString("Username") == null || HttpContext.Session.GetString("Username") == " "))
            {
                HttpContext.Session.SetString("Username", " ");
            }
        }
        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // return page  
            }

            //lambda expression for  author authentication
            var check = _context.Author.Where(a=>a.AUsername==Username).Where(a => a.APassword == Password).Count();

            if (check != 0)
            {                
                HttpContext.Session.SetString("Username", Username);
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage("login");
            }
        }
    }
}
  