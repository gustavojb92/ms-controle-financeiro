
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
    public int UserId { get; set; }

    [Column("value")]
    [Required]
    public Double Value { get; set; }

    [Column("balance")]
    [Required]
    public Double Balance { get; set; }

    [Column("received")]
    [Required]
    public Boolean Received { get; set; }

    [Column("transition_date")]
    [Required]
    public DateTime TransitionDate { get; set; }

    [JsonIgnore]
    public virtual User User { get; set; }
}
