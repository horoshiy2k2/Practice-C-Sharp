using System;
using System.IO;
using System.Xml.Serialization;

namespace SerializedPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var user1 = new User();
            //user1.Age = 5;
            //SerializeXML(user1);
            //user1.Age = 7;
            //SerializeXML(user1);
            DeserializeXML(ref user1);
            Console.WriteLine(user1.Age); //7
        }

        static void SerializeXML(User user)
        {
            var xml = new XmlSerializer(typeof(User));

            using (var fs = new FileStream("user.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, user);
            }
        }

        static void DeserializeXML(ref User user)
        {
            var xml = new XmlSerializer(typeof(User));

            using (var fs = new FileStream("user.xml", FileMode.Open))
            {
                user = xml.Deserialize(fs) as User;
            }
        }
    }

    [Serializable]
    public class User
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
