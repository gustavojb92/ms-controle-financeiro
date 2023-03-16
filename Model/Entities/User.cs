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

    [Column("email")]
    [Required]
    public string Email { get; set; }

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

    [Required]
    [Column("expected_salary")]
    public Double ExpectedSalary { get; set; }

    [Required]
    [Column("balances")]
    public Double Balances { get; set; }

    [JsonIgnore]
    public virtual List<Input> Inputs { get; set; }

    [JsonIgnore]
    public virtual List<Output> Outputs { get; set; }
    [JsonIgnore]
    public virtual List<Log> Logs { get; set; }

}
