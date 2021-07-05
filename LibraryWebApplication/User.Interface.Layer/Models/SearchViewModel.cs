using Data.Access.Layer.Classes;
using System;
using System.Collections.Generic;

namespace User.Interface.Layer.Models
{
    public class SearchViewModel
    {
        public string Name { get; set; }
        public int ISBN { get; set; }
        public DateTime LoanDate { get; set; }
        public int AuthorId { get; set; }
        public IEnumerable<Authors> Authors { get; set; }
    }
}
