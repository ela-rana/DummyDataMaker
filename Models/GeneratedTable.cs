using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace DummyDataMaker.Models
{
    public class GeneratedTable
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DatabaseID { get; set; }

        public virtual GeneratedDatabase Database { get; set; } = null!;
        public virtual ICollection<GeneratedField> GeneratedFields { get; set; }
    }

    public class GeneratedField
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public AllDataTypes? Datatype { get; set; }
        
        public int TableID { get; set; }

        public virtual GeneratedTable Table { get; set; } = null!;

        //public bool IsUnique { get; set; }
        //public bool IsPrimaryKey { get; set; }
        //public bool IsForeignKey { get; set; }
    }

    public enum AllDataTypes
    {
        FirstName,
        MiddleName,
        LastName,
        MiddleInitial,
        NumericID,
        AlphaNumericID,
        AlphaNumericSpecialCharsID,
        PersonalizedList,
        IntegerValues,
        PercentagesInDecimal,
        PercentagesInFractions,
        DecimalValues,
        Date,
        Time
    }
}
