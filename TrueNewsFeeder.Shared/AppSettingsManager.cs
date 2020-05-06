using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace TrueNewsFeeder.Shared
{
    public class AppSettingsManager
    {
        private static AppSettingsManager _instance;

        private JObject _secrets;

        private const string Namespace = "TrueNewsFeeder.Shared";
        private const string FileName = "appsettings.json";

        private AppSettingsManager()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(AppSettingsManager)).Assembly;
            var stream = assembly.GetManifestResourceStream($"{Namespace}.{FileName}");
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                _secrets = JObject.Parse(json);
            }
        }

        public static AppSettingsManager Settings
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppSettingsManager();
                }

                return _instance;
            }
        }

        public string this[string name]
        {
            get
            {
                try
                {
                    var path = name.Split(':');

                    JToken node = _secrets[path[0]];
                    /*
                     * Throwing a Cannot access child value on Newtonsoft.Json.Linq.JProperty Exception because node does not contain childs inside it
                    for (int i = 0; i < path.Length; i++)
                    {
                        node = node[path[i]];
                    }
                    */

                    return node.ToString();
                }
                catch (System.Exception e)
                {
                    Debug.WriteLine("Unable to retrieve secret '{name}'. Error message: " + e.Message);
                    return string.Empty;
                }
            }
        }
    }
}