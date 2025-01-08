

using System.ComponentModel.DataAnnotations;

namespace DTOs.DTOs;

public class UserContactForm
{
    [Required(ErrorMessage = "First Name is required.")]
    public string FirstName { get; set; } = null!;
    [Required(ErrorMessage = "Last Name is required.")]
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PostalNumber { get; set; } = null!;
    public string Municipality { get; set; } = null!;
}
