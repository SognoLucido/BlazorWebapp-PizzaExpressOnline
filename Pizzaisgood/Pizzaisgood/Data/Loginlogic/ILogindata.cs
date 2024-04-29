namespace Pizzaisgood.Data.Loginlogic
{
    public interface ILogindata
    {
        public bool Authlogin(string usr, string passw);

        public string[] Getcredentials();
    }
}
