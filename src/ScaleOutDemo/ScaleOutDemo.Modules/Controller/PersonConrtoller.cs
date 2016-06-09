
namespace ScaleOutDemo.Modules
{
    using XSockets.Core.XSocket;
    using XSockets.Core.XSocket.Helpers;
    using XSockets.Core.Common.Socket.Event.Interface;
    using System.Threading.Tasks;
    using Model;
    using System;
    using XSockets.Core.Common.Protocol;

    public class PersonController : XSocketController
    {
        public async Task CreatePerson(Person p)
        {
            p.id = Guid.NewGuid();
            p.time = DateTime.Now.ToString("hh:mm:ss");

            // SAVE TO DB AND ASSUME THAT ALL WAS OK

            //ScaleOut and send to client on this server

            // Build a custom message with extra info about the origin of the created object
            var m = new
            {
                person = p,
                server = Info.SERVER
            };
            var o = m.AsMessage("personcreated");
            await this.ScaleOut(o, MessageDirection.Out);
            await this.PersonCreated(o);
        }

        public async Task PersonCreated(IMessage m)
        {
            await this.InvokeToAll(m);
        }
    }
}
