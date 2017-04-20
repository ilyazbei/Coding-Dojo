using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class DepWithViewModel : BaseEntity
    {

        [Required(ErrorMessage="Entery is Required")]
        public int? depWith { get; set; }

    }
}