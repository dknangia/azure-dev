using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Level4
{
    public class SwitchesProgram
    {
        public void Run()
        {
            string message = "The following items are available:"
                                + "\n" + "1 – Rope"
                                + "\n" + "2 – Torches"
                                + "\n" + "3 – Climbing Equipment"
                                + "\n" + "4 – Clean Water"
                                + "\n" + "5 – Machete"
                                + "\n" + "6 – Canoe"
                                + "\n" + "7 – Food Supplies"
                                + "\n" + "What number do you want to see the price of?";

            Console.WriteLine(message);
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice > 0 && choice < 8)
            {
                int response = choice switch
                {
                    1 => 10,
                    2 => 15,
                    3 => 25,
                    4 => 1,
                    5 => 20,
                    6 => 200,
                    7 => 1, 8 => 1,
                    _=> throw new ArgumentException("Not a valid selection")
                };

                Console.WriteLine(response + " Gold coins");

            }
        }
    }
}

