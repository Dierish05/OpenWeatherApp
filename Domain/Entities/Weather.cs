using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Weather
    {
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
