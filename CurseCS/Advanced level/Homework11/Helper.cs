using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Homework11
{
    public static class Helper
    {
        public static List<T> GetObjectsFromJson<T>(string path)
        {
            List<T> objects = new List<T>();

            using (var sr = new StreamReader(path))
            {
                objects = sr.GetObjects<T>(); 
            }

            return objects;
        }

        private static List<T> GetObjects<T>(this StreamReader sr)
        {
            var textFromJson = sr.ReadToEnd();
            return JsonConvert.DeserializeObject<List<T>>(textFromJson);
        }

        public static void ShowColletion<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        //Вопрос: реально ли преобразовать List<object> в List<T>?
        //public static List<T> ConvertListObjToListT<T>(List<object> listObj)
        //{
        //    List<T> someClients = listObj.Select(s => (T)s).ToList();
        //    return someClients;
        //}
    }
}
