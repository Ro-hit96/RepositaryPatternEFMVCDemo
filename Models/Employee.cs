using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace RepositaryPatternEFMVCDemo.Models
{
    [Table("Employee1")]
    public class Employee
    {
        [Key]//this is pk colom in Db
        public int id { get; set; }

        public string? name { get; set; }
        [Required]
        public string? email { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public int salary { get; set; }
    }
}
