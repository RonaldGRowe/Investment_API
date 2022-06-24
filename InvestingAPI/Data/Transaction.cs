using System.ComponentModel.DataAnnotations;

namespace InvestingAPI.Data
{
    public class Transaction
    {
     
        public int TransactionId { get; set; }

        public double TransactionAmount { get; set; }
        public string Description { get; set; } = String.Empty;
        public DateTime Date { get; set; }
        public int AccountId { get; set; }  

        public virtual Account Account { get; set; }

   }
}
