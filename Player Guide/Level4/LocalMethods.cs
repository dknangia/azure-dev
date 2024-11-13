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
            int x = 3; 
            Console.WriteLine(Cube(2));
            Console.WriteLine(Cube(3));
            Console.WriteLine(Cube(4));

            static int Cube(int n) => n * n * n;

            void Foo () => Console.WriteLine(x); //Since this method is not marked as static
            //so it can access the local varibale 'x'

            Foo();

        }
    }
}
