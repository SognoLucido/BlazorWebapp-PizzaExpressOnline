using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzaisgood.Model
{
    public class DataitemsModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }


        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal ItemPrice { get; set; }

        [Required]
        [MaxLength(40)]
        public string ImageUrl { get; set; }



        [Required]
        public string CategoryType { get; set ; }

        public bool IsAvailable { get; set; }

    }



    
    public class Orderlistdb
    {

         [Key]
        public int Id { get; set; }

        [Required] 
        public int UserpaymentinfoId { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalPriceperItem { get; set; }

        public DataitemsModel Product { get; set; }

        public Userpaymentinfo Userpaymentinfo { get; set; }


    }



}
