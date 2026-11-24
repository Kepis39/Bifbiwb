using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bibliotekaapi.Models;

public partial class Copy
{
    [Key]
    public string InventoryNumber { get; set; } = null!;

    public int BookId { get; set; }

    public int? ThemeCode { get; set; }

    public int? CopyCount { get; set; }

    [JsonIgnore]
    public virtual Book? Book { get; set; }

    [JsonIgnore]
    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();

    [JsonIgnore]
    public virtual ThematicCatalog? ThemeCodeNavigation { get; set; }
}
