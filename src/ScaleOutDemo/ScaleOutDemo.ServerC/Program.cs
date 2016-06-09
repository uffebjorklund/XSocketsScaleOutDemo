namespace ScaleOutDemo.ServerC
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
            ScaleOutDemo.Modules.Model.Info.SERVER = "C";

            var enterprise = Composable.GetExport<IXSocketsScaleOut>();
            //Scale sevrer C -> A
            enterprise.AddScaleOut("ws://localhost:4502");
            //Scale sevrer C -> B
            enterprise.AddScaleOut("ws://localhost:4503");

            using (var container = XSockets.Plugin.Framework.Composable.GetExport<IXSocketServerContainer>())
            {
                container.Start();
                Console.ReadLine();
            }
        }
    }
}
