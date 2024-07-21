using Task2.Enums;

namespace Task2.DTOs
{
    public class RequestDto
    {
        public int TotalNumberOfPages { get; set; }
        public int SortColumn { get; set; }
        public SortDirection SortDirection { get; set; }

        public int CurrentPage { set; get; }
        public int PageSize { set; get; }

    }
}
