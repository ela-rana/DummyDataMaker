using DummyDataMaker.Models;

namespace DummyDataMaker.Services
{
    /// <summary>
    /// Defines all types of actions that can be performed on our DataGeneration Database 
    /// including CRUD- create, read, update, delete
    /// </summary>
    public interface IGenerateRepository
    {
        void AddDatabase(GeneratedDatabase db);

        void AddTable(GeneratedTable tb);

        void AddField(GeneratedField fd);

        int MaxDatabaseID();
        int MaxTableID();
        int MaxFieldID();

    }


    public class GenerateRepository : IGenerateRepository
    {
        private GenerateContext _generateContext;
        public GenerateRepository(GenerateContext generateContext)
        {
            _generateContext = generateContext;
        }
        public void AddDatabase(GeneratedDatabase db)
        {
            _generateContext.GeneratedDatabases.Add(db);
            _generateContext.SaveChanges();
        }

        public void AddTable(GeneratedTable tb)
        {
            _generateContext.GeneratedTables.Add(tb);
            _generateContext.SaveChanges();
        }

        public void AddField(GeneratedField fd)
        {
            _generateContext.GeneratedFields.Add(fd);
            _generateContext.SaveChanges();
        }

        public int MaxDatabaseID()
        {
            try
            {
                int max = _generateContext.GeneratedDatabases.Max(x => x.Id);
                return max;
            }
            catch(Exception)
            {
                return 0;
            }
            
        }

        public int MaxTableID()
        {
            return _generateContext.GeneratedTables.Max(x => x.Id);
        }

        public int MaxFieldID()
        {
            return _generateContext.GeneratedFields.Max(x => x.Id);
        }
    }
}
