namespace ContactManager.V1.Contracts
{
    public interface IEmployee
    {
        string Name { get; }
    }

    public class Employee : IEmployee
    {
        public string Name { get; }
    }
}
