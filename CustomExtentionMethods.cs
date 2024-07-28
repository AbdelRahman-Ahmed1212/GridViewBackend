using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;
using System.Text.Json;
using Task2.DBContext;
using Task2.DTOs;
using Task2.Enums;
using Task2.Interfaces;
using Task2.Models;
using Task2.ViewModels;

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
        public static string GenerateFilterQuery(this object search)
        {
            List<string> result = [];
            SearchViewModel searchObj = JsonConvert.DeserializeObject<SearchViewModel>(search.ToString());
            foreach (var prop in searchObj.GetType().GetProperties())
            {
                result.Add($"{prop.Name}.toString().contains(\"{prop.GetValue(searchObj)}\")");
            }
            //foreach (var item in filters)
            //{
            //    result.Add($"{item.FieldName}.toString().contains(\"{item.FilterText}\")");
            //}
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
