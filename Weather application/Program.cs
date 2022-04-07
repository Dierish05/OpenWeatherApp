using AppCore.IServices;
using AppCore.Services;
using Autofac;
using Domain.interfaces;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Weather_application.Forms;

namespace Weather_application
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            var builder = new ContainerBuilder();
            builder.RegisterType<WeatherRepository>().As<IConsulta>();
            builder.RegisterType<ConsultaServices>().As<IConsultaServices>();
            var container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmWeather(container.Resolve<IConsultaServices>()));
        }
    }
}
