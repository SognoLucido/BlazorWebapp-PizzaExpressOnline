using Pizzaisgood.Data.BlazorViewDataModel;

namespace Pizzaisgood.Data.Databasecrud
{
    public interface ICrudController
    {
       

        Task<List<ItemGetFromDbModel>> GetItemsBytype(string itemname);


        Task TransationSaving(blazorviewPaymentForm data, Orderlist listitems);

        Task UpdateAdmindata();

        Task<List<ItemsOrderlistmodel>> Getorderbyid(int orderid);

        Task UpdateandDeletewithArchivieddata(int idpara = -1);




    }
}
