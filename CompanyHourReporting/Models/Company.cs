using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CompanyHourReporting.Models {
    public class Company {
        [Key]
        public int Id { get; set; }
        [Required, NotNull]
        public string Name { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
