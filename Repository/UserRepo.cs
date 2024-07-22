using System.Linq.Dynamic.Core;
using Task2.DBContext;
using Task2.DTOs;
using Task2.IRepository;
using Task2.Models;

namespace Task2.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly Context context;
        public UserRepo(Context context)
        {
            this.context = context;
        }
        public IEnumerable<DaUser> GetUsers(RequestDto requestDto)
        {
            IQueryable<DaUser> usersPaginated =
                        context.DaUsers
                               .GenericSort(requestDto)
                               .Skip(requestDto.PageSize * requestDto.CurrentPage)
                               .Take(requestDto.PageSize);
                                




            return usersPaginated;
        }
        public int Count()
        {
            return context.DaUsers.Count();
        }
     
    }
}
