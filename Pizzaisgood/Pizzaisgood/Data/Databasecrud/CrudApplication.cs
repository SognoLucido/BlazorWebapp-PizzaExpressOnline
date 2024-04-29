
using Microsoft.EntityFrameworkCore;
using Pizzaisgood.Data.BlazorViewDataModel;
using Pizzaisgood.InmemoryDatasingleton;
using Pizzaisgood.Model;




namespace Pizzaisgood.Data.Databasecrud
{
    public class CrudApplication : ICrudController
    {

        public readonly ApplicationDbContext _dbcontext;

        public readonly IAdminpagedatasingleton admindata;
        public  CrudApplication(ApplicationDbContext dbcontext, IAdminpagedatasingleton data)
        {
            _dbcontext = dbcontext;
            admindata = data;

        }

    



        public async Task<List<ItemGetFromDbModel>> GetItemsBytype(string itemname)
        {

            List<ItemGetFromDbModel> resultList = new();


            //categorytype: pizza , altro ,drinks


            if (itemname == itemname.ToLower())
            {
                resultList = await _dbcontext.Dataitems
                    .AsNoTracking()
                    .Where(x => x.IsAvailable == true && x.CategoryType == itemname.ToLower())
                    .Select(x => new ItemGetFromDbModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        ItemPrice = x.ItemPrice,
                        ImageUrl = x.ImageUrl,
                    })
                    .ToListAsync();

            }


            return resultList;


        }

        public async Task<List<ItemsOrderlistmodel>> Getorderbyid(int orderid)
        {

            List<ItemsOrderlistmodel> data = await _dbcontext.Orderlistdbz
                       .AsNoTracking()
                       .Where(x => x.UserpaymentinfoId == orderid)
                       .Join(_dbcontext.Dataitems,
                       Orderitemid => Orderitemid.ProductId,
                       Dataitemid => Dataitemid.Id,
                       (Orderitemid, Dataitemid) => new ItemsOrderlistmodel
                       {
                           Quantity = Orderitemid.Quantity,
                           NameItem = Dataitemid.Name,
                           TotalPriceperItem = Orderitemid.TotalPriceperItem.ToString()

                       }).ToListAsync();

            return data;

        }

        public async Task TransationSaving(blazorviewPaymentForm data, Orderlist itemslist)
        {

            var Addbillinginfo = new BillingAddress
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Address = data.Address,
                Address2 = data.Address2,
                County = data.County,
                State = data.State,
                Zip = data.Zip,
                Phonenumber = data.PhoneNumber

            };

            _dbcontext.BillingAddresses.Add(Addbillinginfo);
            await _dbcontext.SaveChangesAsync();


            var addPaymentinfo = new Userpaymentinfo
            {
                BillingAddressId = Addbillinginfo.Id,
                TotalPrice = decimal.Parse(data.Totalprice),
                PaymentMethod = data.PaymentMethod,
                LastFourDigits = data.Cardnumbersinfo.Substring(data.Cardnumbersinfo.Length - 4),
                ExpiryDate = data.ExpiryDate,
                CardHolderName = data.CardHolderName,
                PaymentStatus = data.PaymentStatus,

            };

            _dbcontext.Userpayment.Add(addPaymentinfo);
            await _dbcontext.SaveChangesAsync();


            foreach (var item in itemslist.keyValuePairs)
            {
                var addIteminOrderlist = new Orderlistdb
                {
                    UserpaymentinfoId = addPaymentinfo.Id,
                    ProductId = item.Key,
                    Quantity = item.Value.Item1,
                    TotalPriceperItem = item.Value.Item3,

                };
                _dbcontext.Orderlistdbz.Add(addIteminOrderlist);
            }


            _dbcontext.SaveChanges();


            await UpdateAdmindata();
        }



        public async Task UpdateAdmindata()
        {

            //admindata.Ordermodellist =
            await _dbcontext.Userpayment
                         .AsNoTracking()
                        .Where(x => x.PaymentStatus == true && x.OrderCompleted == false)
                        .Join(_dbcontext.BillingAddresses,
                        paymentinfo => paymentinfo.BillingAddressId,
                        userinfo => userinfo.Id,
                        (order, customer) => new Ordersfixedtoviewmodel
                        {
                            orderid = order.Id,
                            Fullname = $"{customer.FirstName} {customer.LastName}",
                            Address = customer.Address,
                            Totalprice = order.TotalPrice.ToString(),
                            Phonenumber = customer.Phonenumber

                        })
                        .ToMyAdmindic(admindata);



        }


        public async Task UpdateandDeletewithArchivieddata(int idpara = -1)
        {

            if (idpara == -1)
            {
                //admindata.Archiviedorders =
                await _dbcontext.Userpayment
                        .AsNoTracking()
                       .Where(x => x.OrderCompleted == true)
                       .Join(_dbcontext.BillingAddresses,
                       paymentinfo => paymentinfo.BillingAddressId,
                       userinfo => userinfo.Id,
                       (order, customer) => new Archivieddatamodel
                       {
                           Orderid = order.Id,
                           Fullname = $"{customer.FirstName} {customer.LastName}",
                           dateutc = order.ArchiviedUTC,
                           Totalprice = order.TotalPrice.ToString(),
                       })
                       .ToMyAdmindic(admindata);
            }
            else
            {

                await _dbcontext.Userpayment.Where(p => p.Id == idpara)
                                      .ExecuteUpdateAsync(s => s
                  .SetProperty(b => b.OrderCompleted, b => true)
                  .SetProperty(b => b.ArchiviedUTC, b => DateTime.UtcNow));

                await Removeandupdatedic(idpara);


                await admindata.Eventrigger();



         

            }
        }


        private async Task Removeandupdatedic(int x)
        {
            if (admindata.Ordermodellistcopy.Remove(x))
            {

                try
                {
                    var order = await _dbcontext.Userpayment
                   .Where(o => o.Id == x)
                   .Select(o => new Archivieddatamodel
                   {
                       Orderid = o.Id,
                       dateutc = o.ArchiviedUTC,
                       Totalprice = o.TotalPrice.ToString(),
                       Fullname = $"{o.billingAddress.FirstName} {o.billingAddress.LastName}",

                   })
                   .FirstOrDefaultAsync();

                    admindata.Archiviedorderscopy[order.Orderid] = order;


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }



    }

    public static class MurlocExtensions
    {

        public static async Task ToMyAdmindic<TSource>(this IQueryable<TSource> source, IAdminpagedatasingleton adminData, CancellationToken cancellationToken = default(CancellationToken))
        {

            if (source is IQueryable<Ordersfixedtoviewmodel> orderItem)
            {
                await foreach (var item in orderItem.AsAsyncEnumerable().WithCancellation(cancellationToken))
                {


                    adminData.Ordermodellistcopy[item.orderid] = item;

                }
            }
            else if (source is IQueryable<Archivieddatamodel> orderItem2)
            {
                await foreach (var item in orderItem2.AsAsyncEnumerable().WithCancellation(cancellationToken))
                {

                    Console.WriteLine();
                    adminData.Archiviedorderscopy[item.Orderid] = item;

                }
            }

            await adminData.Eventrigger();
        }



       



    }





}



