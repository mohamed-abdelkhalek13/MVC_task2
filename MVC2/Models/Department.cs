using System.ComponentModel.DataAnnotations;

namespace MVC2.Models
{
    public class Department
    {
        public int id { get; set; }
        [StringLength(20)]
        public string? name { get; set; }
        [StringLength(20)]
        public string? location { get; set; }

    }
}
