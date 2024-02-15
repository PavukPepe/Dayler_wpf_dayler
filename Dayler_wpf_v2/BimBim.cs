using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayler_wpf
{
    internal class BimBim
    {
        public static T Read<T>(string filename)
        {
            filename += ".json";
            string json = File.ReadAllText(filename);
            T types = JsonConvert.DeserializeObject<T>(json);
            return types;
        }

        public static void Write<T>(T types, string filename)
        {
            string json = JsonConvert.SerializeObject(types);
            filename += ".json";
            File.WriteAllText(filename, json);
        }
    }
}
