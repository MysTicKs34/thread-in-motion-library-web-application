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
        public bool IsActive { get; set; }
        public virtual Books Book { get; set; }
        public virtual Members Member { get; set; }
        [NotMapped]
        public double PenaltyCalculation => CalculatePenaltyPoint();
        private double CalculatePenaltyPoint()
        {
            int penaltyDayCount = DateTime.Today.Subtract(BorrowingDate.AddDays(30)).Days - 1;
            double coefficient = 0.20, penaltyPoint = penaltyDayCount > 0 ? coefficient : 0;
            int firstFibonacciSeriesMember = 0, secondCalculatedFibonacciSeriesMember = 1, calculatedFibonacciSeriesMember = 0;
            for (int i = 1; i < penaltyDayCount; i++)
            {
                calculatedFibonacciSeriesMember = firstFibonacciSeriesMember + secondCalculatedFibonacciSeriesMember;
                firstFibonacciSeriesMember = secondCalculatedFibonacciSeriesMember;
                secondCalculatedFibonacciSeriesMember = calculatedFibonacciSeriesMember;
                penaltyPoint += coefficient * calculatedFibonacciSeriesMember;
            }

            return penaltyPoint;
        }
    }
}
