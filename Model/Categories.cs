using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Model
{
    public class Categories
    {
        [Key]
        public int CategoriesID { get; set; }
        //        [Required(ErrorMessage = "Enter Head Line ")]
        public string CName { get; set; }
        //       [Required(ErrorMessage = "Enter News Details ")]
        public string CDescription { get; set; }
        //       [Required(ErrorMessage = "Enter City Name")]
      }
}
