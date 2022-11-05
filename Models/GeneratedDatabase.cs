using System.ComponentModel.DataAnnotations;

namespace DummyDataMaker.Models
{
    public class GeneratedDatabase
    {
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
