using System.Diagnostics.Metrics;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ContactManager.V1.Models.Creational
{
    public class Singleton
    {
        private static Singleton? _instance;

        public static int Counter = 0; 

        private Singleton()
        {

        }
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                Counter++;
                _instance = new Singleton();
            }
            return _instance ??= new Singleton();
        }
    }
}
