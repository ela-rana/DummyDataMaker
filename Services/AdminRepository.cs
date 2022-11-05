using DummyDataMaker.Models;

namespace DummyDataMaker.Services
{
    public class AdminRepository : IAdminRepository
    {
        private DataPoolContext _dataPoolContext;
        public AdminRepository(DataPoolContext dataPoolContext)
        {
            _dataPoolContext = dataPoolContext;
        }

        public void AddFirstName(string firstName)
        {
            FirstNamePool firstNamePool = new FirstNamePool();
            firstNamePool.FirstName = firstName;
            _dataPoolContext.Add(firstNamePool);
            _dataPoolContext.SaveChanges();
        }

        public void AddLastName(string lastName)
        {
            LastNamePool lastNamePool = new LastNamePool();
            lastNamePool.LastName = lastName;
            _dataPoolContext.Add(lastNamePool);
            _dataPoolContext.SaveChanges();
        }

        public void DeleteFirstNameRecord(int? ID)
        {
            FirstNamePool? firstNamePool = _dataPoolContext.FirstNamePools.Find(ID);
            if (firstNamePool != null)
            {
                _dataPoolContext.FirstNamePools.Remove(firstNamePool);
                _dataPoolContext.SaveChanges();
            }
        }

        public void DeleteLastNameRecord(int? ID)
        {
            LastNamePool? lastNamePool = _dataPoolContext.LastNamePools.Find(ID);
            if (lastNamePool != null)
            {
                _dataPoolContext.LastNamePools.Remove(lastNamePool);
                _dataPoolContext.SaveChanges();
            }
        }

        public List<FirstNamePool> GetAllFirstNames()
        {
            return _dataPoolContext.FirstNamePools.ToList<FirstNamePool>();
        }

        public List<LastNamePool> GetAllLastNames()
        {
            return _dataPoolContext.LastNamePools.ToList<LastNamePool>();
        }

        public int MaxFirstNameID()
        {
            return _dataPoolContext.FirstNamePools.Max(x => x.Id);
        }

        public int MaxLastNameID()
        {
            return _dataPoolContext.LastNamePools.Max(x => x.Id);
        }
    }
}
