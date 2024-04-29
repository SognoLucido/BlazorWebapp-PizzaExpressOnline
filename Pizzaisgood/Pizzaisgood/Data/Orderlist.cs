using Pizzaisgood.Data.BlazorViewDataModel;
using Pizzaisgood.Model;
using System.Collections.Generic;

namespace Pizzaisgood.Data
{
    public class Orderlist
    {
       public Dictionary<int,(int,string,decimal)> keyValuePairs = new();
        public bool active = false;
       

        public string Totalprice 
        { get 
            {
                if (keyValuePairs.Count > 0)
                {
                    decimal price = 0;

                    foreach(var ez in keyValuePairs)
                    {
                        price +=  ez.Value.Item3;
                    }
                    return price.ToString();
                }
                   
                else return "0";
            }  
        }



        public async Task AddtoorderList(ItemGetFromDbModel item)
        {

            if (keyValuePairs.ContainsKey(item.Id))
            {
               int getwoo = keyValuePairs[item.Id].Item1 ;
                getwoo++;
                keyValuePairs[item.Id] = (getwoo,item.Name,item.ItemPrice*getwoo) ;


            }
            else
            {
               keyValuePairs[item.Id] = (1,item.Name, item.ItemPrice); ;
            }
        }



        public  int Counttotalitems()
        {
            int total = 0;  

            foreach (var item in keyValuePairs)
            {
                total += item.Value.Item1;
            }

            return total;
        }


        public async Task RemoveoneItem(int removeitembyname)
        {
            if (keyValuePairs.ContainsKey(removeitembyname))
            {
                int getwoo = keyValuePairs[removeitembyname].Item1;

                decimal baseprice = keyValuePairs[removeitembyname].Item3 / keyValuePairs[removeitembyname].Item1;

                getwoo--;

                if (getwoo <= 0)
                {
                    keyValuePairs.Remove(removeitembyname);
                }
                else
                {
                    keyValuePairs[removeitembyname] = (getwoo, keyValuePairs[removeitembyname].Item2, keyValuePairs[removeitembyname].Item3 - baseprice );
                }

            }
            

        }

    }
}
