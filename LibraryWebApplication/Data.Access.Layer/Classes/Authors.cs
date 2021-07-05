using Data.Access.Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Access.Layer.Classes
{
    public class Authors : IBaseEntity
    {
        public Authors()
        {
            Books = new List<Books>();
        }
        public int ID { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual ICollection<Books> Books { get; set; }
    }
}
