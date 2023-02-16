using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ms_controle_financeiro.Model.Entities;
[Table("user")]
public class User
{
    [Key]
    [Column("id")]
    [Required]
    public int Id { get; set; }

    [Column("user_login")]
    [Required]
    public string UserLogin { get; set; }

    [Column("password")]
    [Required]
    public string Password { get; set; }

    [Column("name")]
    [Required]
    public string Name { get; set; }

    [Column("birth")]
    [Required]
    public DateTime Birth { get; set; }

    [Column("work")]
    [Required]
    public string Work { get; set; }

    [Column("expected_salary")]
    [Required]
    public Double ExpectedSalary { get; set; }

    [JsonIgnore]
    public virtual List<Input> Inputs { get; set; }

    [JsonIgnore]
    public virtual List<Output> Outputs { get; set; }

    [JsonIgnore]
    public virtual Balance Balances { get; set; }
}
