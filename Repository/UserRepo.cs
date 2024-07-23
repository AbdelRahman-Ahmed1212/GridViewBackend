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
        public IEnumerable<DaUser> GetUsers(RequestDto requestDto)
        {

            var res = GenerateFilterQuery(requestDto.filters);

            IQueryable<DaUser> usersPaginated =
                        context.DaUsers
                               .CustomWhere(res)
                               .GenericSort(requestDto)
                               .Skip(requestDto.PageSize * requestDto.CurrentPage)
                               .Take(requestDto.PageSize);




            return usersPaginated;
        }
        public string GenerateFilterQuery(List<Filter> filters)
        {
            List<string> result = [];
            foreach (var item in filters)
            {
                result.Add($"{item.FieldName}.toString().contains(\"{item.FilterText}\")");     
            }
           return string.Join(" AND ", result);
           
        }
 
        public int Count()
        {
            return context.DaUsers.Count();
        }
     
    }
}
