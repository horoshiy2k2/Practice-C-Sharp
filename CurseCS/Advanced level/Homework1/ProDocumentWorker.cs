using System;
using System.Collections.Generic;
using System.Text;

namespace Za1_1
{
    class ProDocumentWorker : DocumentWorker
    {
        public override void EditDocument()
        {
            Console.WriteLine("Документ отредактирован");
        }

        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Эксперт");
        }

        public override string ToString()
        {
            return "Pro версия";
        }
    }
}

//Создайте производный класс ProDocumentWorker.
//Переопределите соответствующие методы, при переопределении методов выводите следующие строки:
//&quot; Документ отредактирован&quot;, &quot; Документ сохранен в старом формате, сохранение в остальных
//форматах доступно в версии Эксперт&quot;.
