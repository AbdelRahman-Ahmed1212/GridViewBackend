namespace Task2.DTOs
{
    public class ResponseDto<T>
    {
        public int page { set; get; }
        public List<T> Data { set; get; }

        public int TotalNumberOfPages { get; set; }

        public int itemsCount { get; set; }

    }
}
