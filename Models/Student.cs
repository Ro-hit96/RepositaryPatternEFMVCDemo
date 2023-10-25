using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using System.Security.Principal;

namespace RepositaryPatternEFMVCDemo.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]//this is pk colom in Db
        public int Roll_No { get; set; }
        [Required]
        public string? Sname { get; set; }
        [Required]
        public string? City { get; set; }
      
        public int SPercentage { get; set; }
    }
}
