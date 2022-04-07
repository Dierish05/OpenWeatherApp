using AppCore.IServices;
using Domain.Entities;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Services
{
    public class ConsultaServices : IConsultaServices
    {
        private IConsulta consulta;
        public ConsultaServices(IConsulta Consulta)
        {
            this.consulta = Consulta;
        }
        public DateTime convertDateTime(long sec)
        {
            return consulta.convertDateTime(sec);
        }

        public string GetImageLocation(Root info)
        {
            return consulta.GetImageLocation(info);
        }

        public Root getWeather(string city, string APIKey)
        {
            return consulta.getWeather(city, APIKey);
        }

        public string GetTempinC(Root info)
        {
            return consulta.GetTempinC(info);
        }
    }
}
