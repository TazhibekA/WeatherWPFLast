using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
 
using Newtonsoft.Json;
using WeatherWPF;

namespace WeatherWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         Weather weather = new Weather();
        private bool GetJson(string city)
        {
            //string url = $"";

            //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            //HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            //string response;

            //using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            //{
            //    response = streamReader.ReadToEnd();
            //}

            //WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
            //return weatherResponse;
            try
            {
                using (WebClient client = new WebClient())
                {
                    weather = JsonConvert.DeserializeObject<Weather>(client.DownloadString($"http://api.apixu.com/v1/forecast.json?key=cfaae3b46bbb4266bd155654190702&q={city}&days=7"));

                }
            }
            catch {
                return false;
            }
            return true;
            
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (GetJson(city.Text))
            {

                //BitmapImage firstImageSource = new BitmapImage();
                //firstImageSource.BeginInit();
                //firstImageSource.UriSource = new Uri(weather.forecast.forecastday[0].day.condition.icon, UriKind.Relative);
                //firstImageSource.EndInit();

               

                tempC.Text = Convert.ToInt32(weather.forecast.forecastday[0].day.maxtemp_c).ToString() + "°";
                tempC1.Text = Convert.ToInt32(weather.forecast.forecastday[1].day.maxtemp_c).ToString() + "°";
                tempC2.Text = Convert.ToInt32(weather.forecast.forecastday[2].day.maxtemp_c).ToString() + "°";
                tempC3.Text = Convert.ToInt32(weather.forecast.forecastday[3].day.maxtemp_c).ToString() + "°";
                tempC4.Text = Convert.ToInt32(weather.forecast.forecastday[4].day.maxtemp_c).ToString() + "°";
                tempC5.Text = Convert.ToInt32(weather.forecast.forecastday[5].day.maxtemp_c).ToString() + "°";
                tempC6.Text = Convert.ToInt32(weather.forecast.forecastday[6].day.maxtemp_c).ToString() + "°";


                temp.Text = weather.forecast.forecastday[0].date;
                temp1.Text = weather.forecast.forecastday[1].date;
                temp2.Text = weather.forecast.forecastday[2].date;
                temp3.Text = weather.forecast.forecastday[3].date;
                temp4.Text = weather.forecast.forecastday[4].date;
                temp5.Text = weather.forecast.forecastday[5].date;
                temp6.Text = weather.forecast.forecastday[6].date;

                feel.Text = "Восход солнца \n" + weather.forecast.forecastday[0].astro.sunrise + "\n" + "Заход солнца \n" + weather.forecast.forecastday[0].astro.sunset;
                feel1.Text = "Восход солнца \n" + weather.forecast.forecastday[1].astro.sunrise + "\n" + "Заход солнца \n" + weather.forecast.forecastday[1].astro.sunset;
                feel2.Text = "Восход солнца \n" + weather.forecast.forecastday[2].astro.sunrise + "\n" + "Заход солнца \n" + weather.forecast.forecastday[2].astro.sunset;
                feel3.Text = "Восход солнца \n" + weather.forecast.forecastday[3].astro.sunrise + "\n" + "Заход солнца \n" + weather.forecast.forecastday[3].astro.sunset;
                feel4.Text = "Восход солнца \n" + weather.forecast.forecastday[4].astro.sunrise + "\n" + "Заход солнца \n" + weather.forecast.forecastday[4].astro.sunset;
                feel5.Text = "Восход солнца \n" + weather.forecast.forecastday[5].astro.sunrise + "\n" + "Заход солнца \n" + weather.forecast.forecastday[5].astro.sunset;
                feel6.Text = "Восход солнца \n" + weather.forecast.forecastday[6].astro.sunrise + "\n" + "Заход солнца \n" + weather.forecast.forecastday[6].astro.sunset;


                minTemp.Text = "Мин. температура \n" + Convert.ToInt32(weather.forecast.forecastday[0].day.mintemp_c).ToString() + "°";
                minTemp1.Text = "Мин. температура \n" + Convert.ToInt32(weather.forecast.forecastday[1].day.mintemp_c).ToString() + "°";
                minTemp2.Text = "Мин. температура \n" + Convert.ToInt32(weather.forecast.forecastday[2].day.mintemp_c).ToString() + "°";
                minTemp3.Text = "Мин. температура \n" + Convert.ToInt32(weather.forecast.forecastday[3].day.mintemp_c).ToString() + "°";
                minTemp4.Text = "Мин. температура \n" + Convert.ToInt32(weather.forecast.forecastday[4].day.mintemp_c).ToString() + "°";
                minTemp5.Text = "Мин. температура \n" + Convert.ToInt32(weather.forecast.forecastday[5].day.mintemp_c).ToString() + "°";
                minTemp6.Text = "Мин. температура \n" + Convert.ToInt32(weather.forecast.forecastday[6].day.mintemp_c).ToString() + "°";


            }
            else {
                MessageBox.Show("Incorrect city!");
            }




        }
    }
}
