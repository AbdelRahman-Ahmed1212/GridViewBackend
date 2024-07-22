using Task2.DTOs;
using Task2.Models;

namespace Task2.IRepository
{
    public interface IUserRepo
    {
        IEnumerable<DaUser> GetUsers(RequestDto requestDto);
        public int Count();


    }
}
