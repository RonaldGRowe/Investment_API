using System.ComponentModel.DataAnnotations;

namespace InvestingAPI.Data
{
    public class Account
    {
        
        public int AccountId { get; set; }


        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public decimal TotalInvestedAmount { get; set; }
        public decimal InvestmentBalance { get; set; }
        public virtual List<Transaction> Transactions { get; set; }  

        
    }
}
