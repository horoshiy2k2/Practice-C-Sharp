using System;
using System.Collections.Generic;

namespace Z7_3
{
    enum EnumCurrency
    {
        BYN,
        USD,
        EUR,
        RUB,
        PLN
    }

    class Program
    {
        static void Main(string[] args)
        {
            var kurs1 = new Converter(2.62, 3.07, 0.034, 0.68); // usd, eur, rub, pln - стоимость каждой валюты в BYN

            var amount = 100;
            var byn = EnumCurrency.BYN;
            var usd = EnumCurrency.USD;
            var eur = EnumCurrency.EUR;
            var rub = EnumCurrency.RUB;
            var pln = EnumCurrency.PLN;

            //Конвертация из рубля в одну из валют
            Console.WriteLine($"{amount} BYN = {kurs1.ConvertBYNInCurrency(usd, amount):f2} USD");
            Console.WriteLine($"{amount} BYN = {kurs1.ConvertBYNInCurrency(eur, amount):f2} EUR");
            Console.WriteLine($"{amount} BYN = {kurs1.ConvertBYNInCurrency(byn, amount):f2} BYN\n");

            //Конвертация из валют в рубль
            Console.WriteLine($"{amount} USD = {kurs1.ConvertCurrencyInBYN(usd, amount):f2} BYN");
            Console.WriteLine($"{amount} EUR = {kurs1.ConvertCurrencyInBYN(eur, amount):f2} BYN");
            Console.WriteLine($"{amount} BYN = {kurs1.ConvertCurrencyInBYN(byn, amount):f2} BYN\n");

            //Конвертация из одной валюты в другую (значения те же, что и в предыдущей, чтобы проверить.
            Console.WriteLine($"{amount} USD = {kurs1.ConvertCurrencyInCurrency(usd, byn, amount):f2} BYN");
            Console.WriteLine($"{amount} EUR = {kurs1.ConvertCurrencyInCurrency(eur, byn, amount):f2} BYN");
            Console.WriteLine($"{amount} BYN = {kurs1.ConvertCurrencyInCurrency(byn, byn, amount):f2} BYN");

            //USD в EUR и наоборот
            Console.WriteLine($"{amount} USD = {kurs1.ConvertCurrencyInCurrency(usd, eur, amount):f2} EUR");
            Console.WriteLine($"{amount} EUR = {kurs1.ConvertCurrencyInCurrency(eur, usd, amount):f2} USD\n");

            //Злотый и рубль
            Console.WriteLine($"{amount} EUR = {kurs1.ConvertCurrencyInCurrency(eur, pln, amount):f2} PLN");
            Console.WriteLine($"{amount} EUR = {kurs1.ConvertCurrencyInCurrency(eur, rub, amount):f2} RUB");
            Console.WriteLine($"{amount} PLN = {kurs1.ConvertCurrencyInCurrency(pln, rub, amount):f2} RUB\n");

            //Рандомный конвертер

            var rand = new Random();
            var iterations = rand.Next(5, 25);

            int[] arrValueCurrency = (int[])Enum.GetValues(typeof(EnumCurrency)); // Array преобразуем в массив int[]. Чтобы рандомно через индексы вызывать

            for (int i = 0; i < iterations; i++)
            {
                var randomCur1 = (EnumCurrency)arrValueCurrency[rand.Next(0, arrValueCurrency.Length)]; // случайный элемент массива, т.е. случайное значение валюты, которую преобразуем в enum
                var randomCur2 = (EnumCurrency)arrValueCurrency[rand.Next(0, arrValueCurrency.Length)];
                var randomAmount = rand.NextDouble() * 100;

                Console.WriteLine($"{randomAmount:f2} \t{randomCur1} = {kurs1.ConvertCurrencyInCurrency(randomCur1, randomCur2, randomAmount):f2}\t {randomCur2}");

            }
        }
    }

    interface ICurrency
    {
        public double CostBYN { get; set; }
    }

    class USD : ICurrency
    {
        public double CostBYN { get; set; }
    }

    class EUR : ICurrency
    {
        public double CostBYN { get; set; }
    }

    class BYN : ICurrency
    {
        public double CostBYN { get; set; }
    }

    class PLN : ICurrency
    {
        public double CostBYN { get; set; }
    }

    class RUB : ICurrency
    {
        public double CostBYN { get; set; }
    }

    class Converter
    {
        ICurrency _kursUSD;
        ICurrency _kursEUR;
        ICurrency _kursBYN;
        ICurrency _kursPLN; // злотый
        ICurrency _kursRUB; // российский

        // (стоимость 1 usd, стоимость 1 eur ...)
        public Converter(double usd, double eur, double rub, double pln)
        {
            _kursUSD = new USD(); // новый курс для этого конвертера. В другом конвертере можем сделать другой курс
            _kursEUR = new EUR();
            _kursRUB = new RUB();
            _kursPLN = new PLN();
            _kursBYN = new BYN();


            _kursUSD.CostBYN = usd;
            _kursEUR.CostBYN = eur;
            _kursRUB.CostBYN = rub;
            _kursPLN.CostBYN = pln;
            _kursBYN.CostBYN = 1;
        }

        //рубли в валюту
        public double ConvertBYNInCurrency(EnumCurrency cur1 , double amount)
        {
            switch (cur1)
            {
                case EnumCurrency.BYN:
                    return amount;
                case EnumCurrency.USD:
                    return amount / _kursUSD.CostBYN;
                case EnumCurrency.EUR:
                    return amount / _kursEUR.CostBYN;
                case EnumCurrency.RUB:
                    return amount / _kursRUB.CostBYN;
                case EnumCurrency.PLN:
                    return amount / _kursPLN.CostBYN;
                default:
                    throw new Exception();
            }
        }

        //валюта в рубли
        public double ConvertCurrencyInBYN(EnumCurrency cur1, double amount)
        {
            switch (cur1)
            {
                case EnumCurrency.BYN:
                    return amount;
                case EnumCurrency.USD:
                    return amount * _kursUSD.CostBYN;
                case EnumCurrency.EUR:
                    return amount * _kursEUR.CostBYN;
                case EnumCurrency.RUB:
                    return amount * _kursRUB.CostBYN;
                case EnumCurrency.PLN:
                    return amount * _kursPLN.CostBYN;
                default:
                    throw new Exception();
            }
        }

        //любая валюта в любую валюту
        public double ConvertCurrencyInCurrency(EnumCurrency cur1, EnumCurrency cur2, double amount)
        {
            var amountBYN = ConvertCurrencyInBYN(cur1, amount);
            return ConvertBYNInCurrency(cur2, amountBYN);
        }
    }



    
}
