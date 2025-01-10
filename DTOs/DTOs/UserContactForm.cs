

using System.ComponentModel.DataAnnotations;

namespace DTOs.DTOs;

public class UserContactForm
{
    [Required(ErrorMessage = "First Name cannot be left empty.")]
    [RegularExpression(@"^\s*[\p{L}\-']+\s*$", ErrorMessage = "First Name can only contain letters.")]
    public string FirstName { get; set; } = null!;

    [RegularExpression(@"^\s*[\p{L}\-']+\s*$", ErrorMessage = "Last Name can only contain letters.")]
    [Required(ErrorMessage = "Last Name cannot be left empty.")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Email cannot be left empty")]
    [RegularExpression(@"^\s*[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}\s*$", ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = null!;

    [RegularExpression(@"^\s*\+?[0-9]{1,3}?[-.\s]?([0-9]{2,4})?[-.\s]?[0-9]{3,4}[-.\s]?[0-9]{4}\s*$", ErrorMessage = "Please enter a valid phone number.")]
    public string PhoneNumber { get; set; } = null!;

    [RegularExpression(@"^\s*[\p{L}\p{N}\s\-.,]+\s*$", ErrorMessage = "Please enter a valid address.")]
    public string Address { get; set; } = null!;

    [RegularExpression(@"^\s*\d{5}\s*$", ErrorMessage = "Please enter a valid 5 digit postal number.")]
    public string PostalNumber { get; set; } = null!;

    [RegularExpression(@"^\s*[A-Za-zåäöÅÄÖ\- ]{2,100}\s*$", ErrorMessage = "Please enter a valid locality.")]
    public string Locality { get; set; } = null!;

}
