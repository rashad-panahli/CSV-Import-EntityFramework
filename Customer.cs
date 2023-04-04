using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_to_SQL_EF
{
    public class Customer
    {
        [Key] 
        public int Index { get; set; } 
        public string UserId { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateofBirth { get; set; }
        public string JobTitle { get; set; }

    }
}
