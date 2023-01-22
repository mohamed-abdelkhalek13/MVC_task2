using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2.Models
{
    public class Dependent
    {
        [StringLength(20)]
        public string? name { get; set; }
        [StringLength(10)]
        public string? sex { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? birthday { get; set; }
        [StringLength(20)]
        public string? relationship { get; set; }
        public int employeeid { get; set; }
        public virtual Employee? employee { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int order { get; set; }



}
}
