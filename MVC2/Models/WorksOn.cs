namespace MVC2.Models
{
    public class WorksOn
    {
        public int? hours { get; set; }
        public int employeeid { get; set; }
        public int projectid { get; set; }
        public virtual Employee? employee { get; set; }
        public virtual Project? project { get; set; }
    }
}
