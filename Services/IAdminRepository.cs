using DummyDataMaker.Models;

namespace DummyDataMaker.Services
{
    /// <summary>
    /// Defines all types of actions that can be performed on our DataPool 
    /// including CRUD- create, read, update, delete
    /// </summary>
    public interface IAdminRepository
    {
        /// <summary>
        /// Adds the passed FirstName string to the FirstNamePool in our DataPool
        /// </summary>
        /// <param name="firstName">first name string to be added</param>
        void AddFirstName(string firstName);

        /// <summary>
        /// Adds the passed LastName string to the LastNamePool in our DataPool
        /// </summary>
        /// <param name="lastName">last name string to be added</param>
        void AddLastName(string lastName);

        /// <summary>
        /// deletes the First Name record that has the passed ID
        /// </summary>
        /// <param name="ID">the ID of the record to be deleted</param>
        void DeleteFirstNameRecord(int? ID);

        /// <summary>
        /// deletes the Last Name record that has the passed ID
        /// </summary>
        /// <param name="ID">the ID of the record to be deleted</param>
        void DeleteLastNameRecord(int? ID);

        /// <summary>
        /// to get the highest FirstName ID value in the database
        /// </summary>
        /// <returns>highest ID value</returns>
        int MaxFirstNameID();

        /// <summary>
        /// to get the highest LastName ID value in the database
        /// </summary>
        /// <returns>highest ID value</returns>
        int MaxLastNameID();

        /// <summary>
        /// to get all FirstNamePool records from the DataPool
        /// </summary>
        /// <returns>a list of all firstnames in the database</returns>
        List<FirstNamePool> GetAllFirstNames();

        /// <summary>
        /// to get all LastNamePool records from the DataPool
        /// </summary>
        /// <returns>a list of all lastnames in the database</returns>
        List<LastNamePool> GetAllLastNames();
    }
}
