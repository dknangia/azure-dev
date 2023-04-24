using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Csharp.NewFeatures
{
    public static class IndicesAndRanges
    {
        public static void Run()
        {
            var numbers = Enumerable.Range(0, 10).ToArray();

            Console.WriteLine("Complete array");
            var copy = numbers[0..]; // All items int the array 
            Console.WriteLine(string.Join("|", copy));

            Console.WriteLine("All but first item is not included");
            var allButFirst = numbers[1..]; // Exclude the first item of the array e.g. 0
            Console.WriteLine(string.Join("|", allButFirst));


            Console.WriteLine("Last item of the range");
            var lastItemRange = numbers[^2];
            Console.WriteLine(string.Join("|", lastItemRange));


            Console.WriteLine("Custom range 4..^3 e.g. Include from 5the item to next three items");
            var customrange = numbers[4..^3];
            Console.WriteLine(string.Join("|", customrange));

        }
    }
}
