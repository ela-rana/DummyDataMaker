using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DummyDataMaker.Models
{
    public class GeneratedDatabase
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
            
        public string? User { get; set; }
        
        public virtual ICollection<GeneratedTable> GeneratedTables { get; set; }
    }
}
