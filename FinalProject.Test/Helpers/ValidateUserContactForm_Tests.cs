﻿

using DTOs.DTOs;
using Social.Helpers;

namespace FinalProject.Test.Helpers;

public class ValidateUserContactForm_Tests
{
    //Test cases (InlineData) generated by ChatGPT, test method written by me
    [Theory]
    [InlineData("", "Doe")]    // FirstName is empty
    [InlineData("   ", "Doe")] // FirstName is whitespace
    [InlineData("John", "")]    // LastName is empty
    [InlineData("John", "   ")] // LastName is whitespace
    [InlineData("", "")]        // Both are empty
    [InlineData("   ", "   ")]  // Both are whitespace
    public void IsValidUserContactForm_InvalidFirstOrLastName_ReturnsFalse(string firstName, string lastName)
    {
        // Arrange
        var form = new UserContactForm
        {
            FirstName = firstName,
            LastName = lastName
        };

        // Act
        var result = ValidateUserContactForm.IsValidUserContactForm(form);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("John","Smith")]          // Standard expected input
    [InlineData("John ", " Smith")]       // Whitespace included in name input, should be trimmed when user input is read (not expected)
    [InlineData("Hans", "Mattin-Lassei")] // Name includes special character like "-", should not make a difference
    [InlineData(" J I M O T H Y ", " S T E V E N S ")]  // Absurd amount of whitespace, should be acceptable
    public void IsValidUserContactForm_ValidFirstOrLastName_ReturnsTrue(string firstName, string lastName)
    {
        // Arrange 
        var form = new UserContactForm
        {
            FirstName = firstName,
            LastName = lastName
        };
        
        // Act
        var result = ValidateUserContactForm.IsValidUserContactForm(form);
        
        // Assert
        Assert.True(result);
    }


}
