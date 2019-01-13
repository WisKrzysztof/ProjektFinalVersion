using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{ /// <summary>Contains co-ordinates.</summary>
    [Serializable]
    public class Location
    {
        Random rnd = new Random(Guid.NewGuid().GetHashCode());
        private double latitude;  //N-S
        private double longitude; //W-E
        private int altitude;     //In meters
        private string city;      //name of city

        ///<remarks>These are hidden, and not really in actual database. This is to simulate the actual weather, and is generated randomly upon creation of location.</remarks>
        private double temperature;  ///<remarks> in Celcius.</remarks>
        private double humidity;     ///<remarks> in percent.</remarks> 
        private Wind winds;
        //private double windStrength; ///<remarks> In km/h.</remarks> 
        //private int windDirection;   ///<remarks>in Degress, starting with N and going clockwise. </remarks> 
        private double pressure;       ///<remarks> In hPa</remarks> 

        /// <summary>Simulates the time passing. Changes randomly every value in every use of this Method as the time passes. </summary>
        /// <remarks>Humidity has to have a value between 0 and 1.
        /// Wind direction has to have a value between 0 and 360 degree.</remarks>
        public void SimulateTimePassing()
        {
            
            temperature = temperature + rnd.NextDouble() * 10 - 5;          
            humidity = humidity + rnd.NextDouble() - 0.5;
            if (humidity > 1) humidity = 1;
            if (humidity < 0) humidity = 0;
            winds.strength = winds.strength + rnd.NextDouble() * 10 - 5;
            if (winds.strength < 0) winds.strength = 0;
            winds.direction = winds.direction + rnd.NextDouble() * 20 - 10;
            if (winds.direction < 0) winds.direction = winds.direction + 360;
            if (winds.direction > 360) winds.direction = winds.direction - 360;
            pressure = pressure + rnd.NextDouble() * 6 - 3;
            if (pressure < 0) pressure = 0;
        }
 
        

        public double Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                longitude = value;
            }
        }

        public int Altitude
        {
            get
            {
                return altitude;
            }

            set
            {
                altitude = value;
            }
        }

        public string City
        {
            get
            { return city; }
            set
            { city = value; }
        }

        public double Temperature
        {
            get
            {
                return temperature;
            }

            set
            {
                temperature = value;
            }
        }

        public double Humidity
        {
            get
            {
                return humidity;
            }

            set
            {
                humidity = value;
            }
        }

      

        public double Pressure
        {
            get
            {
                return pressure;
            }

            set
            {
                pressure = value;
            }
        }

        public Wind Winds
        {
            get
            {
                return winds;
            }

            set
            {
                winds = value;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="Location"/> class.</summary>
        public Location()
        {            
            Latitude = 0;
            Longitude = 0;
            Altitude = 0;
            City = "";
    }

        /// <summary>Initializes a new instance of the <see cref="Location"/> class.</summary>
        /// <param name="a">The Latitude.</param>
        /// <param name="b">The Longitude.</param>
        /// <param name="x">The Altitude.</param>
        public Location(double a, double b, int x, string n)
        {
            City = n;
            Latitude = a;
            Longitude = b;
            Altitude = x;

            Temperature = rnd.NextDouble() + rnd.Next() % 30 + 5;
            Humidity = rnd.NextDouble();           
            winds.strength = rnd.NextDouble() + rnd.Next() % 100;
            winds.direction = rnd.NextDouble() + rnd.Next() % 360;
            Pressure = rnd.Next() % 80 + 960;
            

        }
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Lokalizacja stacji: "+ City + " "+ "\n");
            sb.Append(Math.Abs(Latitude));
            if (Latitude >= 0) sb.AppendLine("°N");
            else sb.AppendLine("°S");
            sb.Append(Math.Abs(Longitude));
            if (Longitude >= 0) sb.AppendLine("°E");
            else sb.AppendLine("°W");
            sb.Append("Altitude: ");
            sb.Append(Altitude.ToString());
            sb.AppendLine("m");

            return sb.ToString();
        }

    }
}
