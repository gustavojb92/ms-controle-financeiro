using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ms_controle_financeiro.Model.Entities;

[Table("balance")]
public class Balance
{
    [Key]
    [Required]
    [Column("id")]
    public int Id { get; set; }


    [Required]
    [Column("user_id")]
    public int UserId { get; set; }

    [Required]
    [Column("value")]
    public Double Value { get; set; }

    [Required]
    [Column("last_update")]
    public DateTime LastUpdate { get; set; }

    [JsonIgnore]
    public virtual User User { get; set; }


}
