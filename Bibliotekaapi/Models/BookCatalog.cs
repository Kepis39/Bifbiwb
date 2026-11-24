using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Bibliotekaapi.Models;

public partial class BookCatalog
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CatalogId { get; set; }

    public int BookId { get; set; }

    public int ThemeCode { get; set; }

    [JsonIgnore]
    public virtual Book Book { get; set; } = null!;

    [JsonIgnore]
    public virtual ThematicCatalog? ThemeCodeNavigation { get; set; }
}
