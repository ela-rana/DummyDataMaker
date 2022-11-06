namespace DummyDataMaker.Services
{
    /// <summary>
    /// Defines all types of actions that can be performed on our DataGeneration Database 
    /// including CRUD- create, read, update, delete
    /// </summary>
    public interface IGenerateRepository
    {
        void AddDatabase(string databaseName);

        void AddTable(string tableName);

        void AddField(string fieldName);
    }


    public class GenerateRepository : IGenerateRepository
    {
        public void AddDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public void AddField(string fieldName)
        {
            throw new NotImplementedException();
        }

        public void AddTable(string tableName)
        {
            throw new NotImplementedException();
        }
    }
}
