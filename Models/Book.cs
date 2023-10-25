using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using System.Security.Principal;

namespace RepositaryPatternEFMVCDemo.Models
{
    [Table ("Book")]
    public class Book
    {
        [Key]//this is pk colom in Db
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Author { get; set; }
        public int Price { get; set; }
    }
}
