using Level4;
using Level4._3_Party_Deployment;
using System.Reflection.Metadata.Ecma335;

//new SwitchesProgram().Run();


//List<int> intList = new List<int>();
//intList.Add(0);
//intList.Add(1);
    
//intList.Add(2);
//intList.Add(3);
//intList.Add(4);
//intList.Add(5);

//static IEnumerable<int> FilterList(List<int> intList)
//{
//    foreach (int i in intList)
//    {
//        if(i > 4)
//        {
//            yield return i; // Basciall, we removed the need of any temporary list to store this comparsion result
//        }
//    }
//}

//foreach (int i in FilterList(intList))
//{
//    Console.WriteLine(i);
//}


var runProgram = new RunProgram(new MediaGroup());
