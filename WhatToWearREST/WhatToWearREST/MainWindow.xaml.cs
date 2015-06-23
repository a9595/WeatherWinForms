using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Layout.Core;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.NavBar;
using DevExpress.Xpf.Charts;
using DevExpress.Xpf.Gauges;
using WeatherRestClient;


namespace WhatToWearREST
{
    public partial class MainWindow : DXWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            WeatherApiClient weatherRestClient = new WeatherApiClient();

            ForecastDAL forecastDal = weatherRestClient.GetWeatherDal();

            var temperature = forecastDal.currently.temperature;


            var summary = forecastDal.currently.summary;
            var windSpeed = forecastDal.currently.windSpeed;
            bool isRainy = Math.Abs(forecastDal.currently.precipIntensity) > 0.1;
            var humidity = forecastDal.currently.humidity;
            var icon = forecastDal.currently.icon;



            //forecastDal.currently.icon


            labelTemp.Content = temperature.ToString(CultureInfo.InvariantCulture);
            labelSummary.Content = summary;
            labelWind.Content = windSpeed.ToString(provider:CultureInfo.InvariantCulture);
            

            //HEAD
            if (isRainy)
            {
            }

            //imageHead.Source = new BitmapImage(new Uri(@"/Images/weather/shoes.png", UriKind.Relative));

           
    }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
           
            
        }



        private void ClickCity(object sender, EventArgs e)
        {

        }

    }


}
