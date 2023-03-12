using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;

namespace Chapter02.Models
{
    public class IceCream
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class IceCreamDb : DbContext
    {
        public IceCreamDb(DbContextOptions options ):base(options)
        {
            
        }
    }
}

