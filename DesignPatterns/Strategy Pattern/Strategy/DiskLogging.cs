namespace Strategy_Pattern.Strategy;

public class DiskLogging : ILogging
{
    public void DoLogging()
    {
        Console.WriteLine("Disk logging");
    }
}