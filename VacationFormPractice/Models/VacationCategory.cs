using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VacationFormPractice.Models
{
    public class VacationCategory
    {
        [Key]
        public int CategoryID { get; set; }
        public string Country { get; set; }
        public DateTime DateEntered { get; set; }

        public ICollection<VacationPlaces> VacationPlaces { get; set; }
        public VacationCategory()
        {
            this.VacationPlaces = new HashSet<VacationPlaces>();
        }
    }
}
