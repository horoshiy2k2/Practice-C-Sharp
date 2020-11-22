using Newtonsoft.Json;
using Parking.Notifications;
using Parking.Payment;
using System.Collections.Generic;
using System.IO;

namespace Parking.Settings
{
    public static class AppSettings
    {
        public static int FreePeriodInSeconds { get; set; }

        public static int TotalCarPlaces { get; set; }

        public static int DailyReportPeriodInSeconds { get; set; } // когда день завершился, нужно "обновить" таймер, чтобы... -1, периодрепорта в секундах

        public static int PricePerSeconds { get; set; }

        public static string CarsInParkingPath => "cars_in_parking.json"; // машины, которые УЖЕ НА ПАРКОВКЕ . не Содержит ли этот файл инфу о парковке? - .

        public static string ParkedCarsPath => "parked_cars.json"; // просто база машин

        public static string AppSettingsPath => "app_settings.json"; 

        public static bool SendEndFreePeriodEmailNotifications { get; set; }

        public static bool SendEndFreePeriodSmsNotifications { get; set; }

        public static List<INotification> Notifications { get; set; }

        public static Dictionary<string, IPayment> Payments { get; set; }
        

        public static void Initialize()
        {
            using (StreamReader sr = new StreamReader(AppSettingsPath))
            {
                var settings = JsonConvert.DeserializeObject<AppSettingsDeserialization>(sr.ReadToEnd());

                TotalCarPlaces = settings.TotalCarPlaces; 
                FreePeriodInSeconds = settings.FreePeriodInSeconds;
                DailyReportPeriodInSeconds = settings.DailyReportPeriodInSeconds;
                PricePerSeconds = settings.PricePerSeconds;
                SendEndFreePeriodEmailNotifications = settings.SendEndFreePeriodEmailNotifications;
                SendEndFreePeriodSmsNotifications = settings.SendEndFreePeriodSmsNotifications;

                Notifications = new List<INotification>
                {
                    new EmailNotification(),
                    new SmsNotification()
                };

                Payments = new Dictionary<string, IPayment>
                {
                    { "cash", new CashPayment()},
                    { "card",  new CardPayment()}
                };
            }
        }
    }

    public class AppSettingsDeserialization
    {
        public int TotalCarPlaces { get; set; }

        public int FreePeriodInSeconds { get; set; }

        public int DailyReportPeriodInSeconds { get; set; }

        public int PricePerSeconds { get; set; }

        public bool SendEndFreePeriodEmailNotifications { get; set; }

        public bool SendEndFreePeriodSmsNotifications { get; set; }
    }
}
