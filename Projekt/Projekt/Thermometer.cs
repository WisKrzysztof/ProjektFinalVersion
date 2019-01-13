using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    /// <summary>Class defines Thermometer. It inherits class measurer and IMeasurable interface.</summary>
    [Serializable]
    public class Thermometer : Measurer, IMeasurable
    {

        /// <summary>Initializes a new instance of the <see cref="Thermometer"/> class.</summary>
        public Thermometer() : base()
        { }
        /// <summary>Initializes a new instance of the <see cref="Thermometer"/> class.</summary>
        /// <param name="s">The name of the measurer.</param>
        /// <param name="a">The accurancy of the measurer.</param>

        public Thermometer(string s, double a) : base(s,a)
        {       }


        /// <summary>Measures this instance.</summary>
        /// <returns>Rounded temperature which is generated taking into account previouslygiven accuracy.</returns>
        public double Measure()
        {
            
            return Math.Round(location.Temperature - Acc / 2 + rnd.NextDouble() * Acc, 4);
        }
    }
}
