using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VacationFormPractice.Models
{
    public class VacationPlaces
    {
        [Key]
        public int DestinationID { get; set; }
        public string Name { get; set; }
        public string Attractions { get; set; }
        public DateTime? datetime { get; set; }
        public VacationCategory VacationCategoryName { get; set; }
    }
}
