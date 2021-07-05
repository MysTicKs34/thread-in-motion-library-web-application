using Data.Access.Layer.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Access.Layer.Classes
{
    public class BookTransactions : IBaseEntity
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int MemberID { get; set; }
        public DateTime BorrowingDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public virtual Books Book { get; set; }
        public virtual Members Member { get; set; }
    }
}
