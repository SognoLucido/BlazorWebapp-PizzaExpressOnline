using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzaisgood.Data.BlazorViewDataModel
{
    public class blazorviewPaymentForm
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string Address { get; set; }

        public string? Address2 { get; set; }

        [Required]
        public string County { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }



        public const string Credit = "Credit card";
        public const string Debit = "Debit card";
        public const string Paypal = "Paypal";


        [Required]
        [MaxLength(20)]
        public string PaymentMethod { get; set; }


        [Required]
        [MaxLength(20)]
        public string Cardnumbersinfo { get; set; }

        //public string LastFourDigits 
        //{ get=>LastFourDigits; 
        //    set 
        //    {   
        //        if (value.Length >= 4) 
        //        LastFourDigits = value.Substring(value.Length - 4);
        //    } 
        //}
        [Required]
        [MaxLength(3)]
        public string CVV { get; set; }


        //  public DateOnly ExpiryDate { get; set; }
        [Required]
        public string ExpiryDate { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "The card holder name is required")]
        public string CardHolderName { get; set; }
        public bool PaymentStatus { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string PhoneNumber { get; set; }

        

        public string Totalprice {  get; set; }



        public bool notActive = false;

    }


  



}
