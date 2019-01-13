using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    /// <summary>Class defines WindMeter,measurer which measure the degree and strength of the wind. It inherits class measurer.</summary>

    [Serializable]
   public class WindMeter : Measurer
    {


       
        int degAcc;//Degree Accuracy

        /// <summary>Gets or sets the degree accurancy.</summary>
        /// <value>The degree accurancy.</value>
        public int DegAcc
        {
            get
            {
                return degAcc;
            }

            set
            {
                degAcc = value;
            }
        }  /// <summary>Initializes a new instance of the <see cref="WindMeter"/> class.</summary>
        public WindMeter() : base()
        { }
        /// <summary>Initializes a new instance of the <see cref="WindMeter"/> class.</summary>
        /// <param name="s">The name.</param>
        /// <param name="a">Accurancy.</param>
        /// <param name="b">Degree accurancy.</param>
        public WindMeter(string s, double a, int b) : base(s, a)
        { DegAcc = b; }

        /// <summary>Measures this instance.</summary>
        /// <returns>Struct Wind which contains strength and direction.</returns>


        public Wind Measure()
        {
            Wind tmp;

            double p = location.Winds.strength + Acc / 2 + rnd.NextDouble() * Acc;
            double q = location.Winds.direction + DegAcc / 2 + rnd.NextDouble() * DegAcc;
            if (q < 0) q = q + 360;
            if (q > 360) q = q - 360;
            tmp.strength = Math.Round(p, 4);
            tmp.direction = Math.Round(q, 2);

            return tmp;
        }
    }
}
