using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level4
{
    internal class Vector
    {
        public int V1 { get; set; }
        public int V2 { get; set; }

        public Vector(int v1, int v2)
        {
            V1 = v1;
            V2 = v2;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.V1 + v2.V2, v2.V1 + v2.V2);    
        }
    }
}
