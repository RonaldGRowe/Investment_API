using InvestingAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace InvestmentsAPI.DtoModels.Transaction
{
    public class TransactionCreateDto : BaseDto
    {
        [Required]
        [DataType(DataType.Currency)]
        public double TransactionAmount { get; set; }
        [Required]
        [StringLength(150)]
        public string Description { get; set; } = string.Empty;
        
    }
}
