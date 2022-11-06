using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DummyDataMaker.Models
{
    public class GeneratedDatabase
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool GenerateSQL { get; set; }
       
        public bool GenerateCSharp { get; set; }

        [Required]
        public string? DatabaseName { get; set; }
            
        public List<GeneratedTable> GeneratedTables { get; set; }

        public GeneratedDatabase()
        {
            this.GeneratedTables = new List<GeneratedTable>();
        }
    }
}
