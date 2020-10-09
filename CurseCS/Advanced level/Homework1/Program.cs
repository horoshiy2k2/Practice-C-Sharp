using System;
using System.Collections.Generic;

namespace Za1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var proKeys = new List<string>();
            var expKeys = new List<string>();

            var countKeys = 3;
            for (int i = 0; i < countKeys; i++)
            {
                proKeys.Add(Guid.NewGuid().ToString());
                expKeys.Add(Guid.NewGuid().ToString());
            }

            DisplayKeys(proKeys, expKeys);

            DocumentWorker documentWorker = new DocumentWorker();
            while (true)
            {
                Console.WriteLine("\n1)Открыть документ\n2)Редактировать документ\n3)Сохранить документ" +
                    "\n4)Ввести ключ\n5)Версия программы\n6)Показать доступные ключи [только для разработчиков]"); // 5 - текущая версия документворкера

                int choice;
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        documentWorker.OpenDocument();
                        break;
                    case 2:
                        documentWorker.EditDocument();
                        break;
                    case 3:
                        documentWorker.SaveDocument();
                        break;
                    case 4: 
                        RegisterKey(ref documentWorker, ref proKeys, ref expKeys);
                            break;
                    case 5:
                        Console.WriteLine(documentWorker); // выведет его версию
                        break;
                    case 6:
                        DisplayKeys(proKeys, expKeys);
                        break;
                    default:
                        break;
                }
            }
        }

        static void RegisterKey(ref DocumentWorker documentWorker, ref List<string> proKeys, ref List<string> expKeys)
        {
            Console.Write("Введите ключ: ");

            string key = Console.ReadLine();
            if (proKeys.Contains(key))
            {
                documentWorker = new ProDocumentWorker();
                proKeys.Remove(key);
                Console.WriteLine("Введён ключ Pro");
            }
            else if (expKeys.Contains(key))
            {
                documentWorker = new ExpertDocumentWorker();
                expKeys.Remove(key);
                Console.WriteLine("Введён ключ Exp");
            }
            else
            {
                Console.WriteLine("Такого ключа не существует, либо он уже был использован");
            }
        }

        static void DisplayKeys(List<string> proKeys, List<string> expKeys)
        {
            Console.WriteLine("[Доступные Pro ключи]");
            foreach (var key in proKeys)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("\n[Доступные Exp ключи]");
            foreach (var key in expKeys)
            {
                Console.WriteLine(key);
            }
        }
    }
}

//В теле метода Main() реализуйте возможность приема от пользователя номера ключа доступа pro и exp.
//Если пользователь не вводит ключ, он может пользоваться только бесплатной версией (создается
//экземпляр базового класса), если пользователь ввел номера ключа доступа pro и exp, то должен создаться
//экземпляр соответствующей версии класса, приведенный к базовому - DocumentWorker.
//Ключи будут хранится в коллекциях proKeys и expKeys. Для ключей используем Guid.NewGuid().ToString();
//Входной ключ будем проверять в одной из коллекций и если он использован – удаляем его.

//Переопределяем все возможные базовые методы на ваше усмотрение ��