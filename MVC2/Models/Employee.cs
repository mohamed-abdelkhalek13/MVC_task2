using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2.Models
{
    public class Employee
    {
        public int id { get; set; }
        [StringLength(20)]
        public string? fname { get; set; }
        [StringLength(2)]
        public string? minit { get; set; }
        [StringLength(20)]
        public string? lname { get; set; }
        [StringLength(10)]
        public string? sex { get; set; }
        [StringLength(20)]
        public string? address { get; set; }
        public int? salary { get; set; }
        [Column(TypeName ="Date")]
        public DateTime? birthday { get; set; }
        public int? supervisorid { get; set; }
        public int? departmentWFid { get; set; }
        public virtual Employee? supervisor { get; set; }
        public virtual List<WorksOn>? worksOns { get; set; }
        public virtual Department? departmentWF { get; set; }
        public virtual Department? departmentMNG { get; set; }

    }
}
