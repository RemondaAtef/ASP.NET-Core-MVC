using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectExample.Models
{
    public class UsersVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter User Name")]  
        [MinLength(3, ErrorMessage = "Min Len 3")]      
        [MaxLength(10, ErrorMessage = "Max Len 3")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter User Code")]  
        public string UserCode { get; set; }
    }
}
