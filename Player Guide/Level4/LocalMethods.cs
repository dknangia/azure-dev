using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level4
{
    public class LocalMethods
    {
        public void WriteNumbers()
        {
            Console.WriteLine(Cube(2));
            Console.WriteLine(Cube(3));
            Console.WriteLine(Cube(4));

            static int Cube(int n) => n * n * n;

        }
    }
}
