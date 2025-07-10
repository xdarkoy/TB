using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared;

public class ContactDto
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
    public List<PhoneNumberDto> PhoneNumbers { get; set; } = new();
}

public class PhoneNumberDto
{
    public int Id { get; set; }
    [Required]
    public string Number { get; set; } = string.Empty;
    public string? Type { get; set; }
}
