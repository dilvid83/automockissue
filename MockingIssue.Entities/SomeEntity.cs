using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MockingIssue.Entities;

[Table("Barcodes")]
public class SomeEntity : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid SomeModelId { get; set; }

    public Guid RegardingId { get; set; }

    [Required]
    public Guid CountryId { get; set; }

    [ForeignKey("CountryId")]
    public CountryEntity Country { get; set; }

    [Required]
    public string Info { get; set; }
}