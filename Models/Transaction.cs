


using System;
using System.ComponentModel.DataAnnotations;

namespace MauiApp1.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public required string Title { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Debit must be a non-negative number.")]
        public decimal Debit { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Credit must be a non-negative number.")]
        public decimal Credit { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [AtLeastOneRequired]  // Custom Validation for at least one of Debit or Credit should be entered
        public string Validation { get; set; } // For validation only (optional)

        public DateTime Date { get; set; }

        public decimal LoanAmount { get; set; }
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