using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ms_controle_financeiro.Model.Entities;

[Table("input")]
public class Input
{
    [Key]
    [Column("id")]
    [Required]
    public int Id { get; set; }

    [Column("user_id")]
    [Required]
    public int UserId { get; set; }

    [Column("value")]
    [Required]
    public Double Value { get; set; }

    [Column("input_date")]
    [Required]
    public DateTime InputDate { get; set; }

    [Column("to_bank_account")]
    [Required]
    public string ToBankAccount { get; set; }

    [JsonIgnore]
    public virtual User User { get; set; }
}
