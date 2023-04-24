namespace Csharp.NewFeatures
{

    public enum Colors
    {
        Black, 
        Green, 
        Yellow, 
        Mate, 
        White, 
        Unknown
    }

    public class TuplePatternMatch
    {

        public void InvokeFunction()
        {
           Console.WriteLine(GetPattern(Colors.Unknown, Colors.Black).ToString()); 
        }

        public Colors GetPattern(Colors c1, Colors c2)
        {
            return (c1, c2) switch
            {
                (Colors.Black, Colors.Green) => Colors.White,
                (_, _) when c1 == Colors.Black || c2 == Colors.Black => Colors.Black,
                _ => Colors.Unknown
            }; 
        }
         
    }
}
