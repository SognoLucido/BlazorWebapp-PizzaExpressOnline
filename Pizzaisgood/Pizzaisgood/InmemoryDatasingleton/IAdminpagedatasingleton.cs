using Pizzaisgood.Data.BlazorViewDataModel;

namespace Pizzaisgood.InmemoryDatasingleton
{
    public interface IAdminpagedatasingleton
    {

        public event EventHandler DataUpdater;

        Task Eventrigger();


        Dictionary<int, Archivieddatamodel> Archiviedorderscopy { get; set; }

        Dictionary<int, Ordersfixedtoviewmodel> Ordermodellistcopy { get; set; }
    }
}
