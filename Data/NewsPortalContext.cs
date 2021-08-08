using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Model;

namespace NewsPortal.Data
{
    public class NewsPortalContext : DbContext  
    {
        public NewsPortalContext (DbContextOptions<NewsPortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NewsPortal.Model.News> News { get; set; }
        public virtual DbSet<NewsPortal.Model.Categories> Categories { get; set; }
        public virtual DbSet<NewsPortal.Model.Author> Author { get; set; }
    }
}
