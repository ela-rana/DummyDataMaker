namespace DummyDataMaker.Models
{
    public class GeneratedTable
    {
        public List<GeneratedField>? GeneratedFields { get; set; }

        public GeneratedTable()
        {
            this.GeneratedFields = new List<GeneratedField>();
        }

    }

    public class GeneratedField
    {
        public string? Name { get; set; }
        public AllDataTypes? Datatype { get; set; }
        public bool IsUnique { get; set; }
        public bool IsPrimaryKey { get; set; }
        
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
