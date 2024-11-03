namespace Strategy_Pattern.Strategy;

public class Context
{
    public ILogging Logging = null!;


    public void DoLogging()
    {
        Logging.DoLogging();
    }
}