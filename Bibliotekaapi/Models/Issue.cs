using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Bibliotekaapi.Models;

public partial class Issue
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IssueId { get; set; }

    public int TicketNumber { get; set; }

    public string InventoryNumber { get; set; }

    public DateOnly IssueDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public DateOnly? ActualReturn { get; set; }

    [JsonIgnore]
    public virtual Copy? InventoryNumberNavigation { get; set; }

    [JsonIgnore]
    public virtual Reader? TicketNumberNavigation { get; set; }
}
