namespace Task2.ViewModels
{
    public class SearchViewModel
    {
        public int ?id { set; get; }

        public string ?FirstName { get; set; }

        public string ?LastName { get; set; }
        public string ?Email { get; set; }

        public string ?Phone { get; set; }
        public DateOnly? DOB { get; set; }
    }
}
