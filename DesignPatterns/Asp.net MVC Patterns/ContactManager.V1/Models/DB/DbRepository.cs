namespace ContactManager.V1.Models.DB
{
    public class DbRepository
    {
        public void GetData<T>(Func<Person, List<T>> extract)
        {
            Person p = new Person
            {
                Name = "George",
                SurName = "Walmart"
            };

            extract(p);
        }
    }

    public class Caller
    {
        public void GetData()
        {
            List<Employee> ExtractEmployee(Person p)
            {
                var result = new List<Employee> { new() { FirstName = p.Name, LastName = p.SurName } };
                return result;
            }

            var x = new DbRepository();
            x.GetData(ExtractEmployee);
        }

        //private List<Employee> Extract(Person? p)
        //{
        //    var result = new List<Employee>
        //    {
        //        new()
        //        {
        //            FirstName = p.Name,
        //            LastName = p.SurName
        //        }
        //    };
        //    return result;
        //}
    }

    public class Employee
    {
        public  string LastName { get; set; }   
        public string FirstName { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
