using Pizzaisgood.Data.BlazorViewDataModel;
using Pizzaisgood.Data;
using Pizzaisgood.InmemoryDatasingleton;
using Pizzaisgood.Model;
using Microsoft.EntityFrameworkCore;
using Pizzaisgood.Data.Databasecrud;

namespace Pizzaisgood
{
    static public class StaticMethodsGeneric
    {
        static public string Priceaddsimbol(Decimal conversion) => conversion.ToString() + "$";
       
        static public  string  Truepricetostring(int firstnumb , Decimal secondnumb)
        {
            return (firstnumb*secondnumb).ToString();
        } 
    }




    static public class ExtensionMemorystartupfill
    {
        public static async Task<IApplicationBuilder> UseMemoryFill(this IApplicationBuilder app)
        {



            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;

               
                try
                {
                    var mySingletonService = services.GetRequiredService<IAdminpagedatasingleton>();
                    var context = services.GetRequiredService<ApplicationDbContext>();

                    if (context.Database.EnsureCreated())
                    {

                        foreach(var data in StaticTemplatedata.Datafill)
                        {
                            context.Dataitems.Add(data);
                        }

                        context.SaveChanges();

                        Console.WriteLine("db successfully created");
                    }


                    await context.Userpayment
                                    .AsNoTracking()
                                   .Where(x => x.PaymentStatus == true && x.OrderCompleted == false)
                                   .Join(context.BillingAddresses,
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
                                   .ToMyAdmindic(mySingletonService);


                             await context.Userpayment
                                    .AsNoTracking()
                                   .Where(x => x.OrderCompleted == true)
                                   .Join(context.BillingAddresses,
                                   paymentinfo => paymentinfo.BillingAddressId,
                                   userinfo => userinfo.Id,
                                   (order, customer) => new Archivieddatamodel
                                   {
                                       Orderid = order.Id,
                                       Fullname = $"{customer.FirstName} {customer.LastName}",
                                       dateutc = order.ArchiviedUTC,
                                       Totalprice = order.TotalPrice.ToString(),
                                   })
                                   .ToMyAdmindic(mySingletonService);




                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                    Environment.Exit(1);
                }
            }





            return app;
        }

    }
}
