Task<Type2> ConvertToType1(Type1 type1, Action<Type2> extra)
{
    var type2 = new Type2
    {
        Property1 = type1.Property1,
        Property2 = type1.Property2,
        Property3 = type1.Property3
    };

    extra(type2);

    return Task.FromResult(type2);
}


await ConvertToType1(new Type1() { Property1 = "Type2" }, type3 =>
{
    Console.WriteLine(type3.Property1 == Enum.GetName(DifferentTypes.Type1)
        ? "Property1_Type3 is equal to Property1"
        : "Property1_Type3 is not equal to Property1");
});




public class Type1
{
    public string Property1 { get; set; }
    public string Property2 { get; set; }
    public string Property3 { get; set; }
}


public class Type2
{
    public string Property1 { get; set; }
    public string Property2 { get; set; }
    public string Property3 { get; set; }
}




enum DifferentTypes
{
    Type1,
    Type2,
    Type3
}
