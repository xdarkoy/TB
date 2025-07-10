using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared;

public class Contact
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [EmailAddress]
    public string? Email { get; set; }
    public string? Company { get; set; }
    public string? Address { get; set; }
    public string? Notes { get; set; }
    public string? Group { get; set; }
    public List<PhoneNumber> PhoneNumbers { get; set; } = new();
}

public class PhoneNumber
{
    public int Id { get; set; }
    [Required]
    public string Number { get; set; } = string.Empty;
    public string? Type { get; set; }
}
