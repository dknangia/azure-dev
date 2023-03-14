using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Chapter02.Models
{
    public class IceCream
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public static bool TryParse(string? value, IFormatProvider? provider, out IceCream? iceCream)
        {
            if (value == null)
            {
                iceCream = null;
                return false;
            }

            var o = JsonConvert.DeserializeObject<IceCream>(value);
            iceCream = o;
            return true;

        }


    }

    public class IceCreamDb : DbContext
    {
        public IceCreamDb(DbContextOptions options) : base(options)
        {

        }

        public DbSet<IceCream> IceCreams { get; set; }
    }
}


