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


            IQueryable<DaUser> usersPaginated =
                        context.DaUsers
                              // .Where($"{requestDto.searchColumn} = '{requestDto.searchWord}'")
                               .GenericSort(requestDto)
                               .Skip(requestDto.PageSize * requestDto.CurrentPage)
                               .Take(requestDto.PageSize);


         var res =    GenerateFilterQuery(
                    new List<Filter>()
                    {
                        new Filter()
                        {
                            FieldName = "Id",
                            FilterText = "1"
                        },
                             new Filter()
                        {
                            FieldName = "FirstName",
                            FilterText = "s"
                        },
                    });


            return usersPaginated;
        }
        public string GenerateFilterQuery(List<Filter> filters)
        {
            string result = "";
            foreach (var item in filters)
            {
                result =" AND " + item.FieldName + "=" + "'" + item.FilterText + "' ";
            }
            return result;
        }
        public int Count()
        {
            return context.DaUsers.Count();
        }
     
    }
}
