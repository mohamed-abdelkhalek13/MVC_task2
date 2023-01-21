using System.ComponentModel.DataAnnotations;

namespace MVC2.Models
{
    public class Project
    {
        [StringLength(20)]
        public string? name { get; set; }
        public int? id { get; set; }
        [StringLength(20)]
        public string? location { get; set; }
        public int departmentid { get; set; }
        public virtual Department? department { get; set; }   
        public virtual List<WorksOn>? worksOns { get; set; }

    }
}
