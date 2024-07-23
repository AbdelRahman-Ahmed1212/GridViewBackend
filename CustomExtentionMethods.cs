using System.Linq.Dynamic.Core;
using Task2.DBContext;
using Task2.DTOs;
using Task2.Enums;
using Task2.Interfaces;
using Task2.Models;

namespace Task2
{
    public static class CustomExtentionMethods
    {
        public static IOrderedQueryable<DaUser> GenericSort(this IQueryable<DaUser> daUsers, RequestDto requestDto)
        {

            return requestDto.SortDirection ==SortDirection.Asc
                ? daUsers.OrderBy(requestDto.SortColumnName + " asc") :
                  daUsers.OrderBy(requestDto.SortColumnName + " desc");
        }
        public static IQueryable<DaUser> CustomWhere(this IQueryable<DaUser> retreivedUsers, string query)
        {
           
            if (query == "")
                return retreivedUsers;
            return retreivedUsers.Where(query);
        }
        public static string GenerateFilterQuery(this List<Filter> filters)
        {
            List<string> result = [];
            foreach (var item in filters)
            {
                result.Add($"{item.FieldName}.toString().contains(\"{item.FilterText}\")");
            }
            return string.Join(" AND ", result);

        }
        public static IQueryable<DaUser> Paginate(this IQueryable<DaUser> daUsers , RequestDto requestDto)
        {
                  return daUsers.
                                Skip(requestDto.PageSize * requestDto.CurrentPage)
                               .Take(requestDto.PageSize);

        }

    }

}
