using XSockets.Core.Configuration;

namespace ScaleOutDemo.ServerB
{
    public class MyConfiguration : ConfigurationSetting
    {
        public MyConfiguration() : base("ws://127.0.0.1:4504") { }
    }
}
