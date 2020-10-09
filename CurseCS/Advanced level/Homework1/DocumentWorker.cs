using System;
using System.Collections.Generic;
using System.Text;

namespace Za1_1
{
    class DocumentWorker
    {
        public void OpenDocument() {
            Console.WriteLine("Документ открыт");
        }

        public virtual void EditDocument()
        {
            Console.WriteLine("Редактирование документа доступно в версии Про");
        }
        
        public virtual void SaveDocument()
        {
            Console.WriteLine("Сохранение документа доступно в версии Про");
        }

        public override string ToString()
        {
            return "Бесплатная версия";
        }
    }
}

//Создайте класс DocumentWorker.
//В теле класса создайте три метода OpenDocument(), EditDocument(), SaveDocument().
//В тело каждого из методов добавьте вывод на экран соответствующих строк: &quot; Документ открыт&quot;,
//&quot; Редактирование документа доступно в версии Про&quot;, &quot; Сохранение документа доступно в версии
//Про&quot;.
