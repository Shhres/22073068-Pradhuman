//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MauiApp1.Models
//{
//    public class Transaction
//    {
//        public int Id { get; set; }

//        public int UserId { get; set; } // Link transaction to a user

//        public decimal Debit { get; set; } // Cash out

//        public decimal Credit { get; set; } // Cash in

//        public DateTime Date { get; set; }

//        public string Description { get; set; }
//    }
//}


using System;
using System.ComponentModel.DataAnnotations;

namespace MauiApp1.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Debit must be a non-negative number.")]
        public decimal Debit { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Credit must be a non-negative number.")]
        public decimal Credit { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [AtLeastOneRequired]
        public string Validation { get; set; } // Used only for validation

        public DateTime Date { get; set; }
    }

    public class AtLeastOneRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var transaction = (Transaction)validationContext.ObjectInstance;
            if (transaction.Debit > 0 || transaction.Credit > 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Either 'Debit' or 'Credit' must be entered.");
        }
    }
}
