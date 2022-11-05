using System.ComponentModel.DataAnnotations.Schema;

namespace DummyDataMaker.Models
{
    public class FirstNamePool
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }
    }
    public class LastNamePool
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string LastName { get; set; }
    }
}
