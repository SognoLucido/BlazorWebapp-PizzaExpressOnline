using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using Pizzaisgood.Model;
using Pizzaisgood.Data.BlazorViewDataModel;
using System.Runtime.CompilerServices;
using System.Text;


namespace Pizzaisgood.Data
{
   


    public class Generatefakedata
    {

        private readonly HttpClient _httpClient;
        public Generatefakedata(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }


        public async Task<bool> Generatedatafromexternalapi(blazorviewPaymentForm formdata)
        {

            var response = await _httpClient.GetAsync(@"https://randomuser.me/api/");

            if (response.IsSuccessStatusCode)
            {

               Root fakedatamodel = new Root();

              var data = await response.Content.ReadAsStringAsync();

                fakedatamodel = JsonSerializer.Deserialize<Root>(data);



                formdata.PhoneNumber = fakedatamodel.results[0].cell;
                formdata.Email = fakedatamodel.results[0].email;
                formdata.Address = fakedatamodel.results[0].location.street.name;
                formdata.County  = fakedatamodel.results[0].location.country;
                formdata.State = fakedatamodel.results[0].location.state;

                formdata.Zip = fakedatamodel.results[0].location.postcode.ToString();

                // 
                formdata.FirstName = fakedatamodel.results[0].name.first;
                formdata.LastName = fakedatamodel.results[0].name.last;
                formdata.PaymentMethod = "Credit card";
                
                Random random = new Random();   

                formdata.CVV = (random.Next(100, 900) + random.Next(0, 100)).ToString();

                formdata.CardHolderName = $"{formdata.FirstName} {formdata.LastName}";

                formdata.Cardnumbersinfo = Createrandomwtfcard(random);

                formdata.ExpiryDate = $"{random.Next(1, 13)}/{random.Next(24, 50)}";


                return true;
            }

            
            string Createrandomwtfcard(Random rdm)
            {
 
                StringBuilder sb = new StringBuilder();

                for(int i = 0;i < 16; i++)
                {
                  sb.Append(rdm.Next(0,10).ToString());
                }

                return sb.ToString();
            }

            return false;

        }









    }






























}
