namespace Pizzaisgood.Data.Loginlogic
{
    public  class Logindata : AbstractLogindata, ILogindata
    {


        private string Username { get; init; } = "Admin";


      
       

        public string[] Getcredentials()
        {
            return [Username, Password];
        }

       


        public bool Authlogin(string usr, string passw)
        {
            if (usr == Username && passw == Password) return true;

            return false;

        }
    }
}
