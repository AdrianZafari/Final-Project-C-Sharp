

using DTOs.DTOs;
using DTOs.Models;
using Social.Handlers;

namespace Social.Factories;

public class UserFactory
{
    public static UserContactForm Create()
    {
        return new UserContactForm();
    }

    public static UserContactProfile Create(UserContactForm form)
    {
        return new UserContactProfile()
        {
            Id = UniqueIdentifierGenerator.GenerateUserId(),
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.PhoneNumber,
            Address = form.Address,
            Municipality = form.Municipality,
            PostalNumber = form.PostalNumber
        };
    }


}
