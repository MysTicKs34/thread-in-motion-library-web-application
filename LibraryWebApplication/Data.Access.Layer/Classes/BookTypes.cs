using Data.Access.Layer.Interfaces;

namespace Data.Access.Layer.Classes
{
    public class BookTypes : IBaseEntity
    {
        public int ID { get ; set ; }
        public int TypeID { get; set; }
        public int BookID { get; set; }
        public virtual Types Type { get; set; }
        public virtual Books Book { get; set; }
    }
}
