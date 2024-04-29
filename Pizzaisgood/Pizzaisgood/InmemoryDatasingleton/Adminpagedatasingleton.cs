
using Pizzaisgood.Data.BlazorViewDataModel;


namespace Pizzaisgood.InmemoryDatasingleton
{
    public class Adminpagedatasingleton : IAdminpagedatasingleton
    {

        public event EventHandler? DataUpdater;

        public bool test {  get; set; }

 

        public Dictionary<int, Archivieddatamodel> Archiviedorderscopy { get; set; } = new();


        public Dictionary<int, Ordersfixedtoviewmodel> Ordermodellistcopy { get; set; } = new();


        public async Task Eventrigger()
        {
            DataUpdater?.Invoke(this, EventArgs.Empty);
        }


    }
}
