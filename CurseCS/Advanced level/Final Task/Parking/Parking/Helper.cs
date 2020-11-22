using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class Helper
    {
        public static void SerializeJson<T>(string path, List<T> objects) where T : class
        {
            var serializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented
            };

            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, objects);

                Console.WriteLine("Объект cереализован");
            }
        }
    }
}
//для красоты можно ввести и скидывать шлак-методы, которые в трудно сортировать по классам