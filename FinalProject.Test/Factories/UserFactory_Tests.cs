

using DTOs.DTOs;
using DTOs.Models;
using Social.Factories;

namespace FinalProject.Test.Factories;

public class UserFactory_Tests
{
    [Fact]
    public void Create_NoParameter_ReturnsNewUserContactForm()
    {
        // Act
        var form = UserFactory.Create();

        // Assert
        Assert.IsType<UserContactForm>(form);
    }

    [Theory] // Case with invalid first and last name has its handler being tested independantly
    [InlineData("Jimothy", "Stevens", "jimothy.stevens@domain.com", "123-456-7890", "123 Nowhere St", "Helsingborg", "12345")]
    [InlineData("Jimothy", "Stevens", "", "123-456-7890", "123 Nowhere St", "Helsingborg", "12345")]
    [InlineData("Jimothy", "Stevens", "jimothy.stevens@domain.com", "", "", "Helsingborg", "12345")]
    [InlineData("Jimothy", "Stevens", "", "", "", "", "")]
    public void Create_WithValidForm_ReturnsCorrectNewUserProfile(string firstName, 
                                                                  string lastName, 
                                                                  string email,
                                                                  string phoneNumber,
                                                                  string address,
                                                                  string municipality,
                                                                  string postalNumber)
    {
        // Arrange
        var form = new UserContactForm
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            Address = address,
            Municipality = municipality,
            PostalNumber = postalNumber
        };

        // Act
        var profile = UserFactory.Create(form);

        // Assert
        Assert.IsType<UserContactProfile>(profile);  
        Assert.Equal(form.FirstName, profile.FirstName);  
        Assert.Equal(form.LastName, profile.LastName);    
        Assert.Equal(form.Email, profile.Email);          
        Assert.Equal(form.PhoneNumber, profile.PhoneNumber);  
        Assert.Equal(form.Address, profile.Address);      
        Assert.Equal(form.Municipality, profile.Municipality);  
        Assert.Equal(form.PostalNumber, profile.PostalNumber);  


    }

}
