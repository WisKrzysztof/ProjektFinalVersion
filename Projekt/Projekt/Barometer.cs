using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{ /// <summary>Class defines Barometer,measurer which measure the pressure. It inherits class measurer.</summary>
    [Serializable]
    public class Barometer : Measurer, IMeasurable
    {
        public Barometer() : base()
        { }
        public Barometer(string s, double a) : base(s, a)
        { }
        /// <summary>Measures this instance.</summary>
        /// <returns>Rounded pressure which is generated taking into account previously given accuracy.</returns>
        public double Measure()
        {
            double p = location.Pressure - Acc / 2 + rnd.NextDouble() * Acc;
            if (p < 0) return 0;      
            return Math.Round(p,4);
        }


    }
}
