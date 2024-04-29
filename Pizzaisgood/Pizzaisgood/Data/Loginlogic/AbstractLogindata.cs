namespace Pizzaisgood.Data.Loginlogic
{
    public abstract class AbstractLogindata
    {

        protected static string Password { get; private set; }

        public AbstractLogindata() 
        {
            Generatenewcheck();
        }

        private static async  Task Generatenewcheck()
        {
            while (true)
            {
                string pepz = Guid.NewGuid().ToString("N");

                Password = pepz.Substring(pepz.Length - 7);
                await Task.Delay(TimeSpan.FromMinutes(10)); 
            }
        }

    }
}
