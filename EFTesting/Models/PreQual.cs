using System;
using System.Collections.Generic;

namespace EFTesting.Models;

public partial class PreQual
{
    public string CatId { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? ModifiedTime { get; set; }
}
