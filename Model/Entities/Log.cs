
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_controle_financeiro.Model.Entities;

[Table("log")]
public class Log
{
    [Key]
    [Column("id")]
    [Required]
    public int Id { get; set; }

    [Column("user")]
    [Required]
    public string User { get; set; }

    [Column("value")]
    [Required]
    public Double Value { get; set; }

    [Column("transition_type")]
    [Required]
    public string TransitionType { get; set; }

    [Column("transition_date")]
    [Required]
    public DateTime TransitionDate { get; set; }
}
