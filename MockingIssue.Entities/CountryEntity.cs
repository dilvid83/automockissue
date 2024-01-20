using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MockingIssue.Entities;

[Table("Countries")]
public class CountryEntity : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid CountryId { get; set; }

    [Required]
    public string CountryCode { get; set; }

    [Required]
    public string Name { get; set; }
}