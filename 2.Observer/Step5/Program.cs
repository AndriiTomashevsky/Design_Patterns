using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;

namespace Step4
{
    delegate void Observer(float temperature, float humidity, float pressure);

    interface ISubject
    {
        event Observer MeasurementsChangedEvent;
        void NotifyObservers();
        void MeasurementsChanged();
    }
    interface IDisplayElement
    {
        void Display();
    }
    interface IObserver
    {
        void Update(float temperature, float humidity, float pressure);
    }

    class WeatherData : ISubject
    {
        private Observer observers = null;
        private float temperature;
        private float humidity;
        private float pressure;

        public event Observer MeasurementsChangedEvent { add { observers += value; } remove { observers -= value; } }

        public void MeasurementsChanged()
        {
            SetMesurements();
            NotifyObservers();
        }

        public void NotifyObservers()
        {
            observers.Invoke(temperature, humidity, pressure);
        }

        public void SetMesurements()
        {
            try
            {
                //form a webrequest for the html of the weather page
                WebRequest wreq = WebRequest.Create("https://weather.com/uk-UA/weather/today/l/UPXX0016:1:UP");

                // HttpWebResponse is derived from the WebResponse class
                // which provides a response from an URL. WebResponse like
                // WebRequest is an abstract base class and so we
                // cast it to our HttpWebResponse class
                HttpWebResponse wresp = (HttpWebResponse)wreq.GetResponse();
                // now we use the GetResponseStream() method to get
                // the underlying data stream that can be used to read
                // the response
                string HTML = "";
                Stream s = wresp.GetResponseStream();
                StreamReader objReader = new StreamReader(s);

                string sLine = "";
                int i = 0;
                //Dump the stream into a string line by line
                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                        HTML += sLine;
                }

                int start, stop;
                string sDummy = "";

                start = HTML.IndexOf("today_nowcard-temp", 0, HTML.Length);
                stop = HTML.IndexOf("<", start + 28, 10);
                sDummy = HTML.Substring(start + 28, stop - (start + 28));
                temperature = Convert.ToSingle(sDummy.Replace("ass=\"\">", ""));

                start = HTML.IndexOf("<th>Вологість</th>", 0, HTML.Length);
                stop = HTML.IndexOf("<", start + 39, 20);
                sDummy = HTML.Substring(start + 39, stop - (start + 39));
                humidity = Convert.ToSingle(sDummy.Replace("pan>", ""));

                start = HTML.IndexOf("<th>Тиск</th>", 0, HTML.Length);
                stop = HTML.IndexOf(" ", start + 32, 9);
                sDummy = HTML.Substring(start + 32, stop - (start + 32));
                pressure = Convert.ToSingle(sDummy, new CultureInfo("En").NumberFormat);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }

    class CurrentConditionsDisplay : IDisplayElement, IObserver
    {
        private float temperature;
        private float humidity;

        public void Update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            Display();
        }

        public void Display()
        {
            Console.WriteLine($"Current conditions {temperature}C degrees and {humidity} % humidity");
        }
    }

    class StatisticsDisplay : IDisplayElement, IObserver
    {
        private float maxTemp = 0.0f;
        private float minTemp = 200;
        private float tempSum = 0.0f;
        private int numReadings;

        public void Update(float temp, float humidity, float pressure)
        {
            tempSum += temp;
            numReadings++;

            if (temp > maxTemp)
            {
                maxTemp = temp;
            }
            if (temp < minTemp)
            {
                minTemp = temp;
            }
            Display();
        }
        public void Display()
        {
            Console.WriteLine($"Avg/Max/Min temperature = {tempSum / numReadings} / {maxTemp} / {minTemp}");
        }
    }
    class ForecastDisplay : IDisplayElement, IObserver
    {
        private float currentPressure = 29.92f;
        private float lastPressure;

        public void Display()
        {
            Console.Write("Forecast: ");

            if (currentPressure > lastPressure)
            {
                Console.WriteLine("Improving weather on the way!");
            }
            else if (currentPressure == lastPressure)
            {
                Console.WriteLine("More of the same");
            }
            else if ((currentPressure < lastPressure))
            {
                Console.WriteLine("Watch out for cooler, rainy weather");
            }
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            lastPressure = currentPressure;
            currentPressure = pressure;

            Display();
        }
    }
    class HeatIndexDisplay : IDisplayElement, IObserver
    {
        private float heatindex;

        public void Display()
        {
            Console.WriteLine($"Heat index is {heatindex}");
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            heatindex = ComputeHeatIndex(temperature, humidity);
            Display();
        }
        private float ComputeHeatIndex(float temperature, float rh)
        {
            float t = 9 / 5 * temperature + 32;
            float index = (float)((16.923 + (0.185212 * t) + (5.37941 * rh) - (0.100254 * t * rh) +
                (0.00941695 * (t * t)) + (0.00728898 * (rh * rh)) +
                (0.000345372 * (t * t * rh)) - (0.000814971 * (t * rh * rh)) +
                (0.0000102102 * (t * t * rh * rh)) - (0.000038646 * (t * t * t)) + (0.0000291583 *
                (rh * rh * rh)) + (0.00000142721 * (t * t * t * rh)) +
                (0.000000197483 * (t * rh * rh * rh)) - (0.0000000218429 * (t * t * t * rh * rh)) +
                0.000000000843296 * (t * t * rh * rh * rh)) -
                (0.0000000000481975 * (t * t * t * rh * rh * rh)));
            return index;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ISubject weatherData = new WeatherData();
            List<IObserver> list = new List<IObserver> { new ForecastDisplay(),new HeatIndexDisplay(),
                new StatisticsDisplay(),new CurrentConditionsDisplay()};

            foreach (IObserver item in list)
            {
                weatherData.MeasurementsChangedEvent += item.Update; 
            }
            weatherData.MeasurementsChanged();
            weatherData.MeasurementsChanged();

            Console.ReadKey();
        }
    }
}
