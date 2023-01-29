using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2.ViewModels
{
    public class ProjectVM
    {
        [Required(ErrorMessage ="name is required")]
        [MinLength(5, ErrorMessage ="name should be at least 5 characters")]
        public string? name { get; set; }
        [Required(ErrorMessage ="location is required")]
        [Remote("validateLocation", "customValidation", ErrorMessage ="location must be one of the three cities (cairo, alex, or giza)")]
        public string? location { get; set; }
        [Compare("location", ErrorMessage ="this should match your location")]
        public string? confirmLocation { get; set; }
        [Display(Name ="department name")]
        public int departmentid { get; set; }

    }
}
