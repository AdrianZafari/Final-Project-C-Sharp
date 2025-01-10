

using DTOs.DTOs;
using DTOs.Models;
using Social.Handlers;

namespace Social.Factories;

public static class UserFactory
{
    public static UserContactForm Create()
    {
        return new UserContactForm();
    }

    public static UserContactProfile Create(UserContactForm form)
    {
        return new UserContactProfile()
        {
            Id = null!, // This is assigned in the CreateUserProfile() method in UserService. The handler responsible is tested separetely. 
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.PhoneNumber,
            Address = form.Address,
            Locality = form.Locality,
            PostalNumber = form.PostalNumber
        };
    }
}
