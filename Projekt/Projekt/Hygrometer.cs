using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{ /// <summary>
  /// Class defines Hygrometer,measurer which measure the humidity. It inherits class measurer.
  /// </summary>
    [Serializable]
    public class Hygrometer : Measurer
    {
        /// <summary>Initializes a new instance of the <see cref="Hygrometer"/> class.</summary>
        public Hygrometer() : base()
        {      }
        /// <summary>Initializes a new instance of the <see cref="Hygrometer"/> class.</summary>
        /// <param name="s">The name of the measurer.</param>
        /// <param name="a">The accurancy of the measurer.</param>
        public Hygrometer(string s, double a) : base(s,a)
        { }
        /// <summary>Measures this instance.</summary>
        /// <returns>Rounded humidity(in percentage so the value is between 0-1) which is generated taking into account previously given accuracy.</returns>
        public double Measure()
        {
            double p = location.Humidity - Acc/2 + rnd.NextDouble() * Acc;
            if (p > 1) return 1;
            if (p < 0) return 0;
            return Math.Round(p, 4);
           
        }


    }
}
