using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson20
{
    [Serializable]
    public class Car
    {
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int CarModelYear { get; set; }
        public string CarVin { get; set; }

        public override string ToString()
        {
            return $"{CarMake} {CarModel} {CarModelYear}";
        }
    }
}
