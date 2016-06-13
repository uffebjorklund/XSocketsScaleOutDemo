using System.Threading.Tasks;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;
using XSockets.Plugin.Framework;
using XSockets.Plugin.Framework.Attributes;

namespace ScaleOutDemo.Modules.Controller
{
    /// <summary>
    /// There will only be one instance of this class
    /// A singleton...
    /// </summary>
    [XSocketMetadata("DataPump", PluginRange.Internal)]
    public class DataPump : XSocketController
    {
        private PersonController p;
        private int Age = 0;
        public DataPump()
        {
            p = new PersonController();
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    await Task.Delay(100);
                    ++Age;
                    await this.Call<PersonController>().CreatePerson(new Model.Person { age = Age, name = "DataPump" });
                }
            });
        }
    }
}
