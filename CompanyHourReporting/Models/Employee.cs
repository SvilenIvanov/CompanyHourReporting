using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CompanyHourReporting.Models {
    public class Employee {

        [Key]
        public int Id { get; set; }
        [Required, NotNull]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required, NotNull]
        public double Salary { get; set; }
        [Required, NotNull]
        public int Age { get; set; }

        

    }
}
