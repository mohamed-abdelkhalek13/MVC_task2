using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2.Models
{
    public class Department
    {
        public int id { get; set; }
        [StringLength(20)]
        public string? name { get; set; }
        [StringLength(20)]
        public string? location { get; set; }
        [Column(TypeName ="Date")]
        public DateTime? startDate { get; set; }
        public virtual List<Employee>? employees { get; set; }
        [Display(Name = "Manager")]
        public int? employeeid { get; set; }
        public virtual Employee? employee { get; set; }
        public virtual List<Project>? Projects { get; set; }

    }
}
