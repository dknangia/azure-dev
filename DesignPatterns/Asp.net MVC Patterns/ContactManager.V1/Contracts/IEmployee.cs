namespace ContactManager.V1.Contracts
{
    public interface IEmployee
    {
        string Name { get; set; }
    }

    public class Employee : IEmployee
    {
        public string Name { get; set; } = string.Empty;
    }
}
