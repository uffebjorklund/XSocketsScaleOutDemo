namespace ScaleOutDemo.Modules.Model
{
    using System;

    public static class Info { 
        public static string SERVER { get; set; }
    }

    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public Guid id { get; set; }
        public string time { get; set; }
    }
}
