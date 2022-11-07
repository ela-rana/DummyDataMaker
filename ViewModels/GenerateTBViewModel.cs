using DummyDataMaker.Models;

namespace DummyDataMaker.ViewModels
{
    public class GenerateTBViewModel
    {
        public GeneratedTable? tb { get; set; }
        public GeneratedDatabase? db { get; set; }
        public List<GeneratedField>? fields { get; set; }
    }
}
