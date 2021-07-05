using Data.Access.Layer.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Access.Layer.Classes
{
    public class Members : IBaseEntity
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Surname { get; set; }
        public DateTime MembershipDate { get; set; }
    }
}
