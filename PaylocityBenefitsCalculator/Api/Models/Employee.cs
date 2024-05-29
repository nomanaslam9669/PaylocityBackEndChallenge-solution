using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(64)]
    public string? FirstName { get; set; }

    [StringLength(64)]
    public string? LastName { get; set; }

    [Range(1.00, 100_000_000.00, ErrorMessage = "Price must be between 1 and 100 million!")]
    public decimal Salary { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    public ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();
}
