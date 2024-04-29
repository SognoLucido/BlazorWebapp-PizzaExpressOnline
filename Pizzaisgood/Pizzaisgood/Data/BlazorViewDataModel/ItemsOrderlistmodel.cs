using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzaisgood.Data.BlazorViewDataModel
{
    public class ItemsOrderlistmodel
    {
        public int Quantity { get; set; }
       public string NameItem { get; set; }
        public string TotalPriceperItem { get; set; }
    }
}
