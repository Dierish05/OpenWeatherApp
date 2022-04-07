using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using Domain.Entities;
using AppCore.IServices;

namespace Weather_application.Forms
{
    public partial class FrmWeather : Form
    {
        IConsultaServices consultaServices;
        public FrmWeather(IConsultaServices ConsultaServices)
        {
            this.consultaServices = ConsultaServices;
            InitializeComponent();
        }

        string APIKey = "a2fe9eef8b4489336e87394792a3f2de";

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    Root info = consultaServices.getWeather(txtCity.Text, APIKey);

                    picIcon.ImageLocation = consultaServices.GetImageLocation(info);
                    txtCondition.Text = info.weather[0].Main;
                    txtDetails.Text = info.weather[0].Description;
                    txtSunset.Text = consultaServices.convertDateTime(info.sys.Sunset).ToShortTimeString();
                    txtSunrise.Text = consultaServices.convertDateTime(info.sys.Sunrise).ToShortTimeString();
                    txtWindSpeed.Text = info.wind.speed.ToString() + " Km/h";
                    txtPressure.Text = info.main.Pressure.ToString();
                    txtTemp.Text = consultaServices.GetTempinC(info) + " Cº";
                    lblNombre.Text = txtCity.Text;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se encontro el lugar deseado.");
            }
        }
    }
}
