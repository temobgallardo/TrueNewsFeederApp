using System;
using System.IO;
using System.Reflection;

namespace TrueNewsFeeder.Utils
{
    public class Util
    {
        private static readonly Lazy<Util> _instance = new Lazy<Util> (() => new Util());
        private string _nameSpace = "TrueNewsFeeder.Repositories.MockData";

        public static Util Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private Util() { }

        public string ReadResourceFile(string fileName, Type typeOfObject) 
        {
            // You can check the resources within your assembly doing this
            System.Console.WriteLine(this.GetType().Assembly.GetManifestResourceNames());
            var assembly = IntrospectionExtensions.GetTypeInfo(typeOfObject).Assembly;
            var stream = assembly.GetManifestResourceStream($"{_nameSpace}.{fileName}");
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
