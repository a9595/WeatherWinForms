using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherRestClient
{
    public class WeatherApiClient
    {
        // https://api.forecast.io/forecast/9eb41bec29029fdc9c2a713c44b76b40/52.5931,19.0894

        public static String endPoint = "https://api.forecast.io/forecast/9eb41bec29029fdc9c2a713c44b76b40/52.5931,19.0894";
        private static WebClient _syncClient;
        private static ForecastDAL _weatherDal;

        public static ForecastDAL WeatherDal
        {
            get { return _weatherDal; }
        }


        public WeatherApiClient()
        {
            _weatherDal = GetWeatherDal();
            //test

        }


        public DateTime GetCurrentTime()
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(_weatherDal.currently.time).ToLocalTime();
            return dtDateTime;
        }
        public ForecastDAL GetWeatherDal()
        {
            _syncClient = new WebClient();
            var content = _syncClient.DownloadString(endPoint);
            int i = 5;

            //DataContractJsonSerializer serializer = new DataContractJsonSerializer(); 
            _weatherDal = JsonConvert.DeserializeObject<ForecastDAL>(content);

            return _weatherDal;
        }

        public ForecastDAL GetWeatherByCoordinates(float x, float y)
        {
            //TODO: by cords
            return null;
        }

        public double GetCurrentTemp()
        {
            double temperature = _weatherDal.currently.temperature;
            return temperature;
        }
    }
}
