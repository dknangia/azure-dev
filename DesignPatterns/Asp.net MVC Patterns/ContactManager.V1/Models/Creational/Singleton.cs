using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ContactManager.V1.Models.Creational
{
    public class Singleton
    {
        private static Singleton? _instance;

        private Singleton()
        {

        }
        public static Singleton GetInstance()
        {
            return _instance ??= new Singleton();
        }
    }
}
