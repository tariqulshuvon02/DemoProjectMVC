using System.ComponentModel.DataAnnotations;

namespace DemoProjectMVC.Models
{
    public class Employee:Base
    {
        [Required]
        [MaxLength(25)]
        public string Designation { get; set; }= string.Empty;

        [Required]
        public int Salary { get; set; }
    }
}
