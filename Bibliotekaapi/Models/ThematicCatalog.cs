using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Bibliotekaapi.Models;

public partial class ThematicCatalog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ThemeCode { get; set; }

    public string ThemeName { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<BookCatalog> BookCatalogs { get; set; } = new List<BookCatalog>();

    [JsonIgnore]
    public virtual ICollection<Copy> Copies { get; set; } = new List<Copy>();
}
