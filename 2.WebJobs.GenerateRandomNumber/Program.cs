// See https://aka.ms/new-console-template for more information
class Program
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Here is the random number generated between 1 and 99");

        Console.WriteLine(GenerateRandomNumber());

    }

    static int GenerateRandomNumber()
    {
        var rnd = new Random();
        return rnd.Next(1, 99);

    }
}