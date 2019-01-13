using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;


namespace Projekt
{
    /// <summary>Contains List of Weather Stations.</summary>
    [Serializable]
    public class StationList : ICloneable
    {
        string name;
        /// <summary>Gets or sets the station list identifier.</summary>
        /// <value>The station list identifier.</value>
        [Key]
        public int StationListID { get; set; }
        //public List<WeatherStation> list;
        public virtual List<WeatherStation> list { get; set; }

        /// <summary>Adds the specified Weather Station.</summary>
        /// <param name="w">The Weather Station.</param>
        public void Add(WeatherStation w)
        {
            list.Add(w);
        }

        /// <summary>Removes the specified w.</summary>
        /// <param name="w">The Weather Station.</param>
        public void Remove(WeatherStation w)
        {
            if (list.Contains(w))
            { list.Remove(w); }
            else
            { }
        }

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
        /// <summary>Initializes a new instance of the <see cref="StationList"/> class.</summary>
        public StationList()
        {
            list = new List<WeatherStation>();
            Name = "";
        }
        public StationList(string s)
        {
            list = new List<WeatherStation>();
            Name = s;
        }
        /// <summary>Saves to XML.</summary>
        /// <param name="filename">The filename.</param>
        public void SaveXML(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(StationList));
            StreamWriter sw = new StreamWriter(filename);
            serializer.Serialize(sw, this);
            sw.Close();
        }
        /// <summary>Read from XML.</summary>
        /// <param name="filename">The filename.</param>
        /// <returns>Object of Station List.</returns>
        public static Object LoadXML(string filename)
        {
            StationList readList;
            try
            {
                TextReader tr = new StreamReader(filename);
                XmlSerializer serializer = new XmlSerializer(typeof(StationList));
                readList = (StationList)serializer.Deserialize(tr);
                tr.Close();
                return readList;
            }
            catch (FileNotFoundException)
            {
                
                Console.WriteLine("Plik {0} nie istnieje!!!", filename);
            }
            return null;
        }
        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            StationList copy = new StationList(name);
            foreach(WeatherStation x in list)
            {
                copy.list.Add((WeatherStation)x.Clone());
            }

            return copy;
        }

        /// <summary>Sort this instance.</summary>
        public void Sortuj()
        {
            list.Sort();
        }

        /// <summary>Save to database.</summary>
        public void ZapiszDoBazy()
        {
            using (var db = new Model1())
            {
                db.StationListBaza.Add(this);
                db.SaveChanges();


            }
        }

        /// <summary>Write list from database.</summary>
        public static void WypiszListe()
        {
            using (var db = new Model1())
            {
                Console.WriteLine(db.StationListBaza.FirstOrDefault());

            }
        }
        /// <summary>Write full list of Weather Stations and its values.</summary>
        public void MeasureAll()
        {
            Console.WriteLine("==================");
            foreach (WeatherStation x in list)
            {
                Console.WriteLine(x.Name);
                Console.WriteLine(x.MeasureAll());
                Console.WriteLine("------------------");

            }
            Console.WriteLine("==================");
        }

        /// <summary>Converts Station list to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(WeatherStation x in list)
            {
                sb.AppendLine(x.ToString());
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
