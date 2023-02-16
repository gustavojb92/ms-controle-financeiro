
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ms_controle_financeiro.Model.Entities;

[Table("output")]
public class Output
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

    [Column("output_date")]
    [Required]
    public DateTime OutputDate { get; set; }


    [Column("refering_to")]
    [Required]
    public string ReferingTo { get; set; }


    [Column("has_interest")]
    [Required]
    public Boolean HasInterest { get; set; }

    [JsonIgnore]
    public virtual User User { get; set; }
}
