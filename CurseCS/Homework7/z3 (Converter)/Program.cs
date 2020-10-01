using System;

namespace Z7_3_FirstTask
{
    //БЕЗ интерфейов и абстрактных классов 

    class Converter
    {
        private double _kursUSD;
        private double _kursEUR;

        public Converter(double usd, double eur)
        {
            _kursUSD = usd;
            _kursEUR = eur;
        }

        //Возвращает количество валюты, которую можно купить за amount рублей. С помощью абстрактных классов или интерфейсов можно по-другому
        public double ConvertBYNInUSD(double amount)
        {
            return amount / _kursUSD;
        } 
        
        public double ConvertBYNInEUR(double amount)
        {
            return amount / _kursEUR;
        }
        
        public double ConvertUSDInBYN(double amount)
        {
            return amount * _kursUSD;
        } 
        
        public double ConvertEURInBYN(double amount)
        {
            return amount * _kursEUR;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var kurs1 = new Converter(2.62, 3.07);

            //Конвертация из рубля в одну из валют
            var amount = 100;
            Console.WriteLine($"{amount} BYN = {kurs1.ConvertBYNInUSD(amount):f2} USD");
            Console.WriteLine($"{amount} BYN = {kurs1.ConvertBYNInEUR(amount):f2} EUR");

            //Конвертация из валют в рубль
            Console.WriteLine($"{amount} USD = {kurs1.ConvertUSDInBYN(amount):f2} BYN");
            Console.WriteLine($"{amount} EUR = {kurs1.ConvertEURInBYN(amount):f2} BYN");
        }
    }
}
