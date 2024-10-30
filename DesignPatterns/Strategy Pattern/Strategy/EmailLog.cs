using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Strategy_Pattern.Strategy
{
    public interface ILogging
    {
        public void DoLogging();
    }


    public class Context
    {
        public ILogging Logging;


        public void DoLogging()
        {
            Logging.DoLogging();
        }


    }

    public class EmailLogging : ILogging
    {
        public void DoLogging()
        {
            Console.WriteLine("Email logging");
        }
    }

    public class DiskLogging : ILogging
    {
        public void DoLogging()
        {
            Console.WriteLine("Disk logging");
        }
    }
}
