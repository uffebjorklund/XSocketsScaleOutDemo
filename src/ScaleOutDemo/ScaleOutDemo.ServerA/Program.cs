
namespace ScaleOutDemo.ServerA
{
    using System;
    using XSockets.Core.Common.Enterprise;
    using XSockets.Core.Common.Socket;
    using XSockets.Plugin.Framework;

    class Program
    {
        static void Main(string[] args)
        {
            // Set server name to see in the log what happens
            ScaleOutDemo.Modules.Model.Info.SERVER = "A";
            
            var enterprise = Composable.GetExport<IXSocketsScaleOut>();
            //Scale sevrer A -> B
            enterprise.AddScaleOut("ws://localhost:4503");
            //Scale sevrer A -> C
            enterprise.AddScaleOut("ws://localhost:4504");

            using (var container = XSockets.Plugin.Framework.Composable.GetExport<IXSocketServerContainer>())
            {
                container.Start();
                Console.ReadLine();
            }
        }
    }
}
