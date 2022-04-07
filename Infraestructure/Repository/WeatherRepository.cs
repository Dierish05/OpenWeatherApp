using Domain.Entities;
using Domain.interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Infraestructure.Repository
{
    public class WeatherRepository : IConsulta
    {
        public Root getWeather(string city, string APIKey)
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", city, APIKey);
                var json = web.DownloadString(url);
                Root info = JsonConvert.DeserializeObject<Root>(json);

                return info;
            }
        }

        public string GetImageLocation(Root info)
        {
            string ImageLocation = "https://openweathermap.org/img/w/" + info.weather[0].Icon + ".png";
            return ImageLocation;
        }

        public DateTime convertDateTime(long sec)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(sec).ToLocalTime();

            return day;
        }

        public string GetTempinC(Root info)
        {
            string temp = (info.main.Temp - 273.15).ToString();
            return temp;
        }
    }
}
