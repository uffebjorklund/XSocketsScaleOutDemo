namespace ScaleOutDemo.Modules.ScaleOut
{
    using System.Threading.Tasks;
    using XSockets.Core.Common.Enterprise;
    using XSockets.Core.Common.Protocol;
    using XSockets.Core.Common.Socket.Event.Interface;

    using XSockets.Plugin.Framework;
    using XSockets.Plugin.Framework.Attributes;

    [Export(typeof(IXSocketsScaleOut), null, Rewritable.No, InstancePolicy.Shared)]
    public class CustomScaleOut : XSockets.Enterprise.Scaling.XSocketsScaleOut
    {        
        public override async Task Publish(MessageDirection direction, IMessage message, ScaleOutOrigin scaleOutOrigin)
        {
            // Do not scale if the origin is Auto... We only want to scale our own messages.
            if (scaleOutOrigin == ScaleOutOrigin.Auto) return;

            await base.Publish(direction, message, scaleOutOrigin);
        }        
    }
}

