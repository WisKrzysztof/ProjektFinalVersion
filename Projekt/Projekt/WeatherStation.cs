using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projekt
{
    /// <summary>Struct Wind contain its strength and direction (in degrees).</summary>
    [Serializable]

    public struct Wind
    {
        public double strength;
        public double direction;



        /// <summary>Initializes a new instance of the <see cref="Wind"/> struct.</summary>
        /// <param name="a">Strength.</param>
        /// <param name="b">The direction.</param>
        public Wind(double a, double b)
        {
            strength = a;
            direction = b;
        }

        public override string ToString()
        {
            return strength.ToString() + "km/h " + direction.ToString() + "°";
        }

    }

    public struct Weather
    {
        public double temperature;
        public double humidity;
        public Wind winds;
        public double pressure;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Temperature: " + temperature + "°C");
            sb.AppendLine("Humidity: " + humidity + "%");
            sb.AppendLine("Pressure: " + pressure + " hPa");
            sb.AppendLine("Wind: " + winds.ToString());
            return sb.ToString();
        }
    }

    /// <summary>
    /// The weather station has a slot for a Barometer, Hygrometer, Thermometer and WindMeter.
    /// It is empty at the beginning, and it's impossible to put in two Measurers of the same type.
    /// </summary>
    ///<remarks> 
    ///We are not using List<Measurer> for the list of instruments.  
    /// Checking whether instrument of said type is in the Weather Station would be complicated then.
    /// That is why every instrument has its own variable, so that it can easily be substituted or checked if it's null. </remarks>


    public class WeatherStation : ICloneable, IComparable<WeatherStation>
    {


        /// <summary>Gets or sets the weather station identifier.</summary>
        /// <value>The weather station identifier.</value>
        [Key]
        public int WeatherStationID { get; set; }
        public virtual StationList StationListBaza { get; set; }

        public Location loc;
        public string name;
        public Thermometer thermo;
        public WindMeter anemo;
        public Barometer bar;
        public Hygrometer hygro;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public Thermometer Thermo
        {
            get
            {
                return thermo;
            }

            set
            {
                thermo = value;
            }
        }

        public WindMeter Anemo
        {
            get
            {
                return anemo;
            }

            set
            {
                anemo = value;
            }
        }

        public Barometer Bar
        {
            get
            {
                return bar;
            }

            set
            {
                bar = value;
            }
        }

        public Hygrometer Hygro
        {
            get
            {
                return hygro;
            }

            set
            {
                hygro = value;
            }
        }

        //This compares the locations of the Weather Stations.
        //From the lowest to highest, then from south to north, then from the west to east.
        /// <summary>Compares to.</summary>
        /// <param name="w">The Weather Station</param>
        /// <returns>Int.</returns>
        public int CompareTo(WeatherStation w) 
        {
            if (loc == w.loc) return 0;
            if (loc.Altitude != w.loc.Altitude) return loc.Altitude.CompareTo(w.loc.Altitude);
            if (loc.Latitude != w.loc.Latitude) return loc.Latitude.CompareTo(w.loc.Latitude);
            return loc.Longitude.CompareTo(w.loc.Longitude);
        }
        /// <summary>Initializes a new instance of the <see cref="WeatherStation"/> class.</summary>
        public WeatherStation()
        {
            Name = "";
            loc = null;
            Thermo = null;
            Anemo = null;
            Bar = null;
            Hygro = null;

        }

        /// <summary>Initializes a new instance of the <see cref="WeatherStation"/> class.</summary>
        /// <param name="s">The name</param>
        /// <param name="l">The Location</param>
        public WeatherStation(string s, Location l)
        {
            Name = s;
            loc = l;
            Thermo = null;
            Anemo = null;
            Bar = null;
            Hygro = null;

        }
        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            WeatherStation cl = new WeatherStation(Name, loc);
            if (Thermo!=null) cl.Insert((Thermometer)Thermo.Clone());
            if (Anemo != null) cl.Insert((WindMeter)Anemo.Clone());
            if (Bar != null) cl.Insert((Barometer)Bar.Clone());
            if (Hygro != null) cl.Insert((Hygrometer)Hygro.Clone());

            return cl;
        }

        /// <summary>Inserts the specified Measurer.</summary>
        /// <param name="m">The Measurer.</param>
        /// <remarks>If there have been a measurer of this type already it is replaced and location of the ol measurer is changed to null.</remarks>
        public void Insert(Measurer m)
        {
            Type tp = m.GetType();
            if (tp == typeof(Thermometer)) {
                if (Thermo != null) Thermo.location = null;
                Thermo = (Thermometer)m; m.location = loc;
            }
            if (tp == typeof(Barometer)) {
                if (Bar != null) Bar.location = null;
                Bar = (Barometer)m; m.location = loc;
            }
            if (tp == typeof(WindMeter)) {
                if (Anemo != null) Anemo.location = null;
                Anemo = (WindMeter)m; m.location = loc;
            }
            if (tp == typeof(Hygrometer)) {
                if (Hygro != null) Hygro.location = null;
                Hygro = (Hygrometer)m; m.location = loc;
            }

        }
        /// <summary>Gets the temperature.</summary>
        /// <returns>Temperature or null if there is no measurer.</returns>
        public double getTemperature()
        {
            if (Thermo == null) return Double.NaN;
            return Thermo.Measure();
        }
        /// <summary>Gets the pressure.</summary>
        /// <returns>Pressure or null if there is no measurer.</returns>
        public double getPressure()
        {
            if (Bar == null) return Double.NaN;
            return Bar.Measure();
        }
        /// <summary>Gets the Humidity.</summary>
        /// <returns>Humidity or null if there is no measurer.</returns>
        public double getHumidity()
        {
            if (Hygro == null) return Double.NaN;
            return Hygro.Measure();
        }
        /// <summary>Gets the wind.</summary>
        /// <returns>Wind or null if there is no measurer.</returns>
        public Wind getWind()
        {
            if (Anemo == null) return new Wind(Double.NaN, Double.NaN);
            return Anemo.Measure();
        }
        /// <summary>Create a new object of Weather.</summary>
        /// <returns>Return Weather object.</returns>
        public Weather MeasureAll()
        {
            Weather tmp = new Weather(); ;
            tmp.temperature = getTemperature();
            tmp.pressure = getPressure();
            tmp.humidity = getHumidity();
            tmp.winds = getWind();
            
            return tmp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(name);
            sb.AppendLine("Modules: ");
            if (Thermo != null) { sb.Append("Thermometer: "); sb.AppendLine(Thermo.Name); }
            if (Anemo != null) { sb.Append("Wind Meter: "); sb.AppendLine(Anemo.Name); }
            if (Bar != null) { sb.Append("Barometer: "); sb.AppendLine(Bar.Name); }
            if (Hygro != null) { sb.Append("Hygrometer: "); sb.AppendLine(Hygro.Name); }



            return sb.ToString();
        }


    }
}
