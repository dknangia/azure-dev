using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManager.V1.Models;

[Table("Customers")]
public class Customer
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerID { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string Country { get; set; }
}