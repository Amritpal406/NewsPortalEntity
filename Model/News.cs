using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Model
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }
        //        [Required(ErrorMessage = "Enter Head Line ")]
        public string HLine { get; set; }
 //       [Required(ErrorMessage = "Enter News Details ")]
        public string NDetails { get; set; }
 //       [Required(ErrorMessage = "Enter City Name")]
        public string NCity { get; set; }        
//        [Required(ErrorMessage = "Enter Date")]
        public string NDate { get; set; }
        public string NCategory { get; set; }
        public string NAuthor { get; set; }
    }
}
