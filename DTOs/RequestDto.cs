﻿using Task2.Enums;
using Task2.Interfaces;

namespace Task2.DTOs
{
    public class RequestDto
    {
        public string SortColumnName { get; set; }
        public SortDirection SortDirection { get; set; }

        public int CurrentPage { set; get; }
        public int PageSize { set; get; }

        public string searchObj { set; get; }

    }
}
