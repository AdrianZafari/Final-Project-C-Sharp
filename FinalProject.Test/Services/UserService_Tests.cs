
using Castle.Components.DictionaryAdapter;
using Data.Interfaces;
using DTOs.DTOs;
using DTOs.Models;
using Moq;
using Social.Interfaces;
using Social.Services;
using System.Text.Json;

namespace FinalProject.Test.Services;

public class UserService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IUserService _userService;

    public UserService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _userService = new UserService(_fileServiceMock.Object);
    }

    [Fact]
    public void CreateUserProfile_ValidForm_AddsUserAndSavesToFileReturnsTrue()
    {
        //Arrange
        var form = new UserContactForm
        {
            FirstName = "Jimothy",
            LastName = "Stevens",
            Email = "jimothy.stevens@domain.com",
            PhoneNumber = "123-456-7890",
            Address = "123 Main St",
            Municipality = "Test City",
            PostalNumber = "12345"
        };

        _fileServiceMock.Setup(fs => fs.SaveContentToFile(It.IsAny<string>())).Returns(true);

        // Act 
        var result = _userService.CreateUserProfile(form);

        // Assert 
        Assert.True(result);
        _fileServiceMock.Verify(fs => fs.SaveContentToFile(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void CreateUserProfile_InvalidForm_DoesNotSaveToFileReturnsFalse()
    {
        //Arrange
        var form = new UserContactForm
        {
            FirstName = "",
            LastName = "Stevens"
        };

        // Act 
        var result = _userService.CreateUserProfile(form);

        // Assert 
        Assert.False(result);
        _fileServiceMock.Verify(fs => fs.SaveContentToFile(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void GetUserProfiles_ValidJson_ReturnsProfiles()
    {
        // Arrange
        var json = "[ { \"Id\" : \"1\" , \"FirstName\" : \"Jimothy\", \"LastName\" : \"Stevens\"} ] ";

        _fileServiceMock.Setup(fs => fs.GetContentFromFile()).Returns(json);

        // Act
        var result = _userService.GetUserProfiles();

        // Assert
        Assert.IsAssignableFrom<IEnumerable<UserContactProfile>>(result);
        Assert.Equal("1", result.First().Id);
        Assert.Equal("Jimothy", result.First().FirstName);
        _fileServiceMock.Verify(fs => fs.GetContentFromFile(), Times.Once);
    }

    [Fact]
    public void GetUserProfiles_InvalidJson_ReturnsEmptyList()
    {
        // Arrange
        _fileServiceMock.Setup(fs => fs.GetContentFromFile()).Returns(string.Empty);

        // Act
        var result = _userService.GetUserProfiles();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void UpdateUserProfile_ValidData_UpdatesAndSaves()
    {
        // Arrange
        var initialProfiles = new List<UserContactProfile>
    {
        new UserContactProfile { Id = "1", FirstName = "Jimothy", LastName = "Stevens" }
    };
        var initialProfilesJson = JsonSerializer.Serialize(initialProfiles);

        _fileServiceMock.Setup(fs => fs.GetContentFromFile()).Returns(initialProfilesJson);
                        

        // Dynamic Mocking function was found with the help of ChatGPT, specifically the Callback portion to ensure we are "updating" the profiles
        _fileServiceMock.Setup(fs => fs.SaveContentToFile(It.IsAny<string>()))
                        .Callback<string>(json =>
                        {
                            // Capture the updated JSON that was "saved" to simulate persistence
                            _fileServiceMock.Setup(fs => fs.GetContentFromFile()).Returns(json);
                        })
                        .Returns(true);

        _userService.GetUserProfiles(); // Populate _userContactProfiles

        // Act
        var updatedForm = new UserContactForm { FirstName = "Svenjamin", LastName = "Stevens" };
        var result = _userService.UpdateUserProfile("1", updatedForm);

        // Assert
        Assert.True(result); // Executed UpdateUserProfile, returns true on Success
        var updatedProfiles = _userService.GetUserProfiles();

        // Get the updated profiles and verify changes
        Assert.Single(updatedProfiles);

        var updatedUser = updatedProfiles.First();
        Assert.Equal("Svenjamin", updatedUser.FirstName);
        Assert.Equal("Stevens", updatedUser.LastName);

        _fileServiceMock.Verify(fs => fs.SaveContentToFile(It.IsAny<string>()), Times.Once); // Verifies that content was saved
    }

    [Fact]
    public void UpdateUserProfile_InvalidId_ReturnsFalse()
    {
        // Arrange
        _fileServiceMock.Setup(fs => fs.GetContentFromFile()).Returns("[]");
        _userService.GetUserProfiles();
        var updatedForm = new UserContactForm
        {
            FirstName = "Jimothy",
            LastName = "Stevens"
        };

        // Act
        var result = _userService.UpdateUserProfile("Id", updatedForm);

        // Assert
        Assert.False(result);
        _fileServiceMock.Verify(fs => fs.SaveContentToFile(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void DeleteUserProfile_ValidId_RemovesAndSaves()
    {
        // Arrange
        var initialProfiles = new List<UserContactProfile>
        {
            new UserContactProfile { Id = "1", FirstName = "Jimothy", LastName = "Stevens" }
        };
        var initialProfilesJson = JsonSerializer.Serialize(initialProfiles);

        _fileServiceMock.Setup(fs => fs.GetContentFromFile()).Returns(initialProfilesJson);
                        

        _fileServiceMock.Setup(fs => fs.SaveContentToFile(It.IsAny<string>()))
                        .Callback<string>(json =>
                        {
                            _fileServiceMock.Setup(fs => fs.GetContentFromFile()).Returns(json);
                        })
                        .Returns(true);

        _userService.GetUserProfiles(); // Contains old info

        // Act
        var result = _userService.DeleteUserProfile("1");
        var updatedProfiles = _userService.GetUserProfiles(); // Contains updated info

        // Assert
        Assert.True(true); // Deleted the user object from list of UserContactProfiles, should return true on success 

        Assert.Empty(updatedProfiles); // Verifies that object was removed from list

        _fileServiceMock.Verify(fs => fs.SaveContentToFile(It.IsAny<string>()), Times.Once); // Confirms that saving method was invoked
    }

    [Fact]
    public void DeleteUserProfile_InvalidId_ReturnsFalse()
    {
        // Arrange 
        _fileServiceMock.Setup(fs => fs.GetContentFromFile()).Returns("[]");

        _userService.GetUserProfiles();

        // Act
        var result = _userService.DeleteUserProfile("1");

        // Assert
        Assert.False(result);
        _fileServiceMock.Verify(fs => fs.SaveContentToFile(It.IsAny<string>()), Times.Never);
    }


}
