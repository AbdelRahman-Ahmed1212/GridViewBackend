using System.Linq.Dynamic.Core;
using Task2.DBContext;
using Task2.DTOs;
using Task2.Interfaces;
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
        public IEnumerable<DaUser> GetUsers(RequestDto requestDto , string filterQuery)
        {


            IQueryable<DaUser> usersPaginated =
                        context.DaUsers
                               .CustomWhere(filterQuery)
                               .GenericSort(requestDto)
                               .Paginate(requestDto);




            return usersPaginated;
        }
  
 
        public int Count(string query)
        {
            return context.DaUsers.CustomWhere(query).Count();
        }
     
    }
}
