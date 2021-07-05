using Data.Access.Layer.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Access.Layer.Classes
{
    public class Books : IBaseEntity
    {
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }
        public DateTime LoanDate { get; set; }
        public int StockQuantity { get; set; }
    }
}
