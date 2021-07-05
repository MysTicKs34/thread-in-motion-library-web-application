using Data.Access.Layer.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Access.Layer.Classes
{
    public class Types : IBaseEntity
    {
        public Types()
        {
            BookTypes = new List<BookTypes>();
        }
        public int ID { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Type { get; set; }
        public virtual ICollection<BookTypes> BookTypes { get; set; }
    }
}
