namespace Strategy_Pattern.Strategy;

public class EmailLogging : ILogging
{
    public void DoLogging()
    {
        Console.WriteLine("Email logging");
    }
}