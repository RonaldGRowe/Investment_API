using System.ComponentModel.DataAnnotations;

namespace InvestmentsAPI.DtoModels.Account
{
    public class AccountEditDto : BaseDto   
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;


    }
}
