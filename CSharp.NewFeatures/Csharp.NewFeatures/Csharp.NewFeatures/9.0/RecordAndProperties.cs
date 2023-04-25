namespace Csharp.NewFeatures._9._0
{

    public record EmployeeDto(int Id, string FirstName, string LastName, string Position);

    public record ManagerDto
        (int Id, string FirstName, string LastName, string Position, string Location, double Salary) : EmployeeDto(Id,
            FirstName, LastName, Position); 

    public static class RecordAndProperties
    {
        public static void Initialize()
        {
            var mgrDto = new ManagerDto(
                101, "Mark", "King", "Manager-1", "USA", 1000.00);

            var empDto = new EmployeeDto(101, "Mark", "King", "Manager-1"); 

            var result = mgrDto == empDto;

            var (_, _, _, number4) = new NewClassBaseClass(null, null, null, 5);

            new NewClassBaseClass(null, null, null, 5).PrintingNumbers();

            Console.WriteLine($"discard pattern example : {number4}");

        }

    }

    public class NewClassBaseClass
    {
        public int? Number1 { get; set; }
        public int? Number2 { get; set; }
        public int? Number3 { get; set; }
        public int? Number4 { get; set; }

        public NewClassBaseClass(int? number1, int? number2, int? number3, int? number4)
        {
            Number1 = number1;
            Number2 = number2;
            Number3 = number3;
            Number4 = number4;
        }

        public void Deconstruct(out int? number1, out int? number2, out int? number3, out int? number4)
        {
            number1 = Number1;
            number2 = Number2;
            number3 = Number3;
            number4 = Number4;
        }

        /// <summary>
        /// Printing number description
        /// </summary>
        public void PrintingNumbers()
        {

        }
    }


    public class OldClass : NewClassBaseClass
    {
        public OldClass(int? number1, int? number2, int? number3, int? number4) : base(number1, number2, number3, number4)
        {

        }


        ///<inheritdoc cref="PrintingNumbers"/>
        public new void PrintingNumbers()
        {

        }
    }
}
