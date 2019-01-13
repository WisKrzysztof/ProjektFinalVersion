using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{ /// <summary>Abstract class Measurer contains name, location and accurancy.Inherit ICloneable interface.</summary>
  ///<remarks> Even though location is a pointer, we don't want to create a new location,
  /// because Measurer doesn't contain the location, it only points to it.
  /// That's why shallow copy works here.</remarks>
    [Serializable]
    public abstract class Measurer: ICloneable
    {
        public Random rnd = new Random(Guid.NewGuid().GetHashCode());
        private string name;
        public Location location;
        private double acc;
        
        
        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone() 
        {
            return MemberwiseClone();
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

        public double Acc
        {
            get
            {
                return acc;
            }

            set
            {
                acc = value;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="Measurer"/> class.</summary>
        public Measurer()
        {
            Name = "";
            location = null;
            Acc = 0;
        }
        /// <summary>Initializes a new instance of the <see cref="Measurer"/> class.</summary>
        /// <param name="s">The name of the measurer.</param>
        /// <param name="a">The accurancy of the measurer.</param>
        public Measurer(string s, double a)
        {
            Name = s;
            location = null;
            Acc = a;
        }


    }
}
