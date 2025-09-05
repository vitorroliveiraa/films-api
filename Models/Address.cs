using System.ComponentModel.DataAnnotations;

namespace films_api.Models;

public class Address
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string StateOrProvince { get; set; }
    public string ZipOrPostalCode { get; set; }
    public string Country { get; set; }
    public virtual Cinema cinena { get; set; }
}