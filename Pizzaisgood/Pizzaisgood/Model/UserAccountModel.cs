using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzaisgood.Model
{


    [Table("payment_information")]
    public class Userpaymentinfo
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int BillingAddressId { get; set; }



        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalPrice { get; set; }


        [MaxLength(20)]
        public string PaymentMethod { get; set; }

        [Column("CardLast4")]

        [MaxLength(4)]
        public string LastFourDigits { get; set; }


        [MaxLength(5)]
        public string ExpiryDate { get; set; }

        [MaxLength(50)]
        public string CardHolderName { get; set; }

        public bool PaymentStatus { get; set; }

        public bool OrderCompleted { get; set; } 

        public DateTime? ArchiviedUTC { get; set; }

        public BillingAddress billingAddress { get; set; }

    }





    public class BillingAddress
    {

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string Address { get; set; }

        public string? Address2 { get; set; }

        public string County { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }


        [MaxLength(20)]
        public string Phonenumber { get; set; }

    

    }





}
