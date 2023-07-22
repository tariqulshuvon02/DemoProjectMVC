using System.ComponentModel.DataAnnotations;

namespace DemoProjectMVC.Models
{
    public class Base
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }= string.Empty;
        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }= string.Empty;

        public int CreateBy { get; set; }
        public int UpdateBy { get; set; }
        public DateTimeOffset? CreateDate { get; set; }
        public DateTimeOffset? UpdateDate { get; set;}

    }
    
}
