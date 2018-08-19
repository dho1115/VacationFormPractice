using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VacationFormPractice.Data;

namespace VacationFormPractice.Models
{
    public class TravelerProfile
    {
        [Key]
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DreamDestination { get; set; }
        public string email { get; set; }
        public int? phoneNumber { get; set; }
        public decimal budget { get; set; }
    }
}
