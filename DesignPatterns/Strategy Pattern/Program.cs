// See https://aka.ms/new-console-template for more information

using Strategy_Pattern.Strategy;



Context context = new Context
{
    Logging = new EmailLogging()
};
context.DoLogging();

Console.WriteLine("****************");

context.Logging = new DiskLogging();
context.DoLogging();
