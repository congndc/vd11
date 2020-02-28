using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vd11.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

       
       
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Lỗi Mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lỗi Password")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Lỗi ConfirmPassword")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Lỗi IsPassword")]
        public bool IsPassword { get; set; }
    }
}
