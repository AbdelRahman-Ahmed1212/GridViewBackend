using Task2.DTOs;
using Task2.Interfaces;
using Task2.Models;

namespace Task2.IRepository
{
    public interface IUserRepo
    {
        IEnumerable<DaUser> GetUsers(RequestDto requestDtom, string filterQuery);
        public int Count(string query);

        #region  Helpers

       
        #endregion


    }
}
