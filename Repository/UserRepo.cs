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
        public IEnumerable<DaUser> GetUsers(int page, int pageSize)
        {
            IQueryable<DaUser> usersPaginated =
                        context.DaUsers.Skip(page * pageSize)
                                        .Take(pageSize)
                                        


            return usersPaginated;
        }
    }
}
