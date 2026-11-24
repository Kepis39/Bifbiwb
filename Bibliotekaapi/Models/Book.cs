using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Bibliotekaapi.Models;

public partial class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string? FirstAuthor { get; set; }

    public string? Publisher { get; set; }

    public string? PlaceOfPublication { get; set; }

    public int? YearOfPublication { get; set; }

    public int? PageCount { get; set; }

    public decimal? Price { get; set; }

    [JsonIgnore]
    public virtual ICollection<BookCatalog> BookCatalogs { get; set; } = new List<BookCatalog>();

    [JsonIgnore]
    public virtual ICollection<Copy> Copies { get; set; } = new List<Copy>();
}
