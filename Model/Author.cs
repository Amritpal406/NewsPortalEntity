using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Model
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        //        [Required(ErrorMessage = "Enter Head Line ")]
        public string AName { get; set; }
        //       [Required(ErrorMessage = "Enter News Details ")]
        public string AEmail { get; set; }
        //       [Required(ErrorMessage = "Enter City Name")]
        public string AUsername { get; set; }
        //        [Required(ErrorMessage = "Enter Date")]
        public string APassword { get; set; }
    }
}
