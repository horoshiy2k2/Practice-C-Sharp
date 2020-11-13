using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lesson20
{
    public static class Helper
    {
        public static List<T> GetObjects<T>(string path) // дженерик
        {
            List<T> objects;

            using (var sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), path)))
            {
                objects = sr.GetObject<T>();
            }

            return objects;
        }

        public static List<T> GetObject<T>(this StreamReader sr) // обязательно this Streamreader и статик
        {
            var textFromJson = sr.ReadToEnd();
            return JsonConvert.DeserializeObject<List<T>>(textFromJson);
        }
    }
}
