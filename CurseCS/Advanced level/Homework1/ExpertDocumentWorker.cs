using System;
using System.Collections.Generic;
using System.Text;

namespace Za1_1
{
    class ExpertDocumentWorker : ProDocumentWorker
    {
        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в новом формате");
        }

        public override string ToString()
        {
            return "Exp версия";
        }
    }
}

//Создайте производный класс ExpertDocumentWorker от базового класса ProDocumentWorker.
//Переопределите соответствующий метод. При вызове данного метода необходимо выводить на экран
//&quot; Документ сохранен в новом формате&quot;.
