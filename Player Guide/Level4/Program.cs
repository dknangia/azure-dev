// Level 4 chapter
using Level4;

PgAdapger pgAdapger = new PgAdapger();
var o = pgAdapger.GetT<ClassA>(new ClassArgument());

Console.WriteLine(o.GetType().Name);

