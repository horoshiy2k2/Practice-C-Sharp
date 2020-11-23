using Parking.DailyReport;
using Parking.Models;
using Parking.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parking
{
    public static class ReportDay
    {
        public static List<ParkedCar> CarsPerDay { get; set; } = new List<ParkedCar>();

        public static List<LeavedCar> LeavedCars { get; set; } = new List<LeavedCar>();

        public static List<LeftCar> LeftCars { get; set; } = new List<LeftCar>();

        public static List<PaidClent> PaidClents { get; set; } = new List<PaidClent>();

        public static void PrintDailyReport(object obj)
        {
            var parkedCars = obj as List<ParkedCar>;

            foreach (var parkedCar in parkedCars)
            {
                LeftCars.Add(new LeftCar() { TotalSecondsInParking = (DateTime.Now - parkedCar.InitialParkingTime).Value.TotalSeconds });
            }

            using (var sw = new StreamWriter(AppSettings.DailyReportPath))
            {
                sw.WriteLine($"Количество машин за день: {CarsPerDay.Count}\n");

                if (CarsPerDay.Count != 0)
                {
                    sw.WriteLine($"Машины за день:\n");

                    foreach (var car in CarsPerDay)
                    {
                        sw.WriteLine($"{car}\n**********************************************\n");
                    }
                }
                
                var timePaidCarsInParkingInSeconds = LeavedCars.Select(x => x.TotalSecondsInParking).Sum();
                var timeLeftCarsInParkingInSeconds = LeftCars.Select(x => x.TotalSecondsInParking).Sum();

                var averageTimeInParkingInSeconds = (timePaidCarsInParkingInSeconds + timeLeftCarsInParkingInSeconds) / (LeavedCars.Count + LeftCars.Count);

                sw.WriteLine($"Среднее количество секунд на парковке: {averageTimeInParkingInSeconds:f2}\n");

                if (PaidClents.Count != 0)
                {
                    sw.WriteLine($"Данные о клиентах, которые оплатили:\n");

                    foreach (var client in PaidClents)
                    {
                        sw.WriteLine(client);
                    }

                    var averageCheck = PaidClents.Select(x => x.Amount).Average();

                    sw.WriteLine($"\nСредняя сумма оплаты: {averageCheck:f2}$\n");

                    var maxChek = PaidClents.Select(x => x.Amount).Max();
                    var mostRichClient = PaidClents.First(x => x.Amount == maxChek);

                    sw.WriteLine($"Максимальная сумма оплаты: {maxChek:f2}$ информация о клиенте:\n{mostRichClient}\n");

                    var countCashClient = PaidClents.Where(x => x.PaymentMethod == "cash").Count();
                    var countCardClient = PaidClents.Where(x => x.PaymentMethod == "card").Count();

                    sw.WriteLine($"Количество оплат по карте: {countCardClient}, наличными: {countCashClient}\n");
                }
                else
                {
                    sw.WriteLine("Сегодня нет клиентов, которые платили");
                }
            }

            Console.WriteLine($"{DateTime.Now:T}\n\nОтчёт за день записан");

            ClearStateDailyReport();

            // Зациклили таймер
            var periodTimeSpanDailyReport = DateTime.Now.AddSeconds(AppSettings.DailyReportPeriodInSeconds) - DateTime.Now;
            var printDailyReportTimerCallback = new TimerCallback(ReportDay.PrintDailyReport);
            var timerDailyReport = new Timer(printDailyReportTimerCallback, parkedCars, periodTimeSpanDailyReport, Timeout.InfiniteTimeSpan); // поменял местами. Бесконечно выполняется, период - 

        }

        private static void ClearStateDailyReport()
        {
            CarsPerDay.Clear();
            LeavedCars.Clear();
            LeftCars.Clear();
            PaidClents.Clear();
        }
    }
}