using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level4
{
    public class ClassA
    {
        public int Property1 { get; set; }
    }

    public class ClassB
    {
        public string Property1 { get; set; } = string.Empty;
    }

    public class ClassArgument
    {

    }

    public class PgAdapger
    {
        public T GetT<T>(ClassArgument argument)
        {
            Type type = typeof(T);
            if (type == typeof(ClassA))
            {
                return (T)Convert.ChangeType(new ClassA(), typeof(T));
            }
            else
            {
                return (T)Convert.ChangeType(new ClassB(), typeof(T));
            }
        }
    }
}
