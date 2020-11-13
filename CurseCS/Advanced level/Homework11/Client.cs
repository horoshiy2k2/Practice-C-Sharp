using System;
using System.Collections.Generic;
using System.Text;

namespace Homework11
{
    [Serializable]
    class Client 
    { 
        public string CarModel { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Name}\t\"{Phone}\"\tModel: {CarModel}";
        }
    }
}
