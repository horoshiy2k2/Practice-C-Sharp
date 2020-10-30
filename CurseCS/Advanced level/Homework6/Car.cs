using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace HomeWork17
{
    [Serializable]
    internal class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        [JsonProperty("Year of creation")]
        public DateTime Year { get; set; }

        public string Mileage { get; set; }
        public double Cost { get; set; }

        public DateTime AfterNYears { get; set; }
        public string CostAfterNYears { get; set; }
        public string MileageAfterNYears { get; set; }

        

        public override string ToString()
        {
            return $"{Brand} {Model} {Year.Year}";
        }
    }
}

//"Brand":"Ford","Model":"Escape","Year of creation":"12/22/2003","Mileage":85000,"Cost":547000},