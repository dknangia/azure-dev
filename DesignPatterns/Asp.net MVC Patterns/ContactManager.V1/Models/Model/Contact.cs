using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManager.V1.Models.Model;

[Table("Contacts")] // This should match with the table name in DB.
public class Contact
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] 
    [StringLength(50)] 
    public string FirstName { get; set; }

    [Required] 
    [StringLength(50)] 
    public string LastName { get; set; }

    [Required] 
    [StringLength(50)] 
    public string Email { get; set;  }
    [Required] 
    [StringLength(20)] 
    public string Phone { get; set; }
}