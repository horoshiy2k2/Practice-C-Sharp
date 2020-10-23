using System;
using System.Reflection;

namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom(@"D:\MyLibrary.dll");
            Console.WriteLine(asm.FullName);

            var typeAsm = asm.GetType("MyLibrary.ConverterTemperature");

            var propF = typeAsm.GetProperty("CurrentFahrenheitValue");
            var propC = typeAsm.GetProperty("CurrentСelsiusValue");

            var methodCtoF = typeAsm.GetMethod("FromСelsiusToFahrenheit");
            var methodFtoC = typeAsm.GetMethod("FromFahrenheitToСelsius");

            //т.к. класс статический, то не нужно создавать экземпляр: Activator.CreateInstance(...)

            methodCtoF.Invoke(null, new object[] { 25 });
            methodFtoC.Invoke(null, new object[] { 100 });

            Console.WriteLine(propF.GetValue(null));
            Console.WriteLine(propC.GetValue(null));
        }
    }
}
