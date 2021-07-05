using Data.Access.Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Access.Layer.Classes
{
    public class Books : IBaseEntity
    {
        public Books()
        {
            BookTypes = new List<BookTypes>();
        }
        public int ID { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }
        public DateTime LoanDate { get; set; }
        public int StockQuantity { get; set; }
        public int AuthorID { get; set; }
        public virtual Authors Author { get; set; }
        public virtual ICollection<BookTypes> BookTypes { get; set; }
    }
}
