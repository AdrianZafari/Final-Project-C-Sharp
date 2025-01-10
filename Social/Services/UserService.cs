

using Data.Interfaces;
using DTOs.DTOs;
using DTOs.Models;
using Social.Factories;
using Social.Handlers;
using Social.Interfaces;
using System.Diagnostics;
using System.Text.Json;

namespace Social.Services;

public class UserService: IUserService
{
    private readonly IFileService _fileService;
    private List<UserContactProfile> _userContactProfiles = new List<UserContactProfile>();
    public string json = string.Empty;

    public UserService(IFileService fileService)
    {
        _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
    }


    public bool CreateUserProfile(UserContactForm form)
    {
        if (!ValidateUserContactForm.IsValidUserContactForm(form))
        {
            Debug.WriteLine($"Invalid first or last name given on user contact form.");
            return false;
        }

        try
        {
            var userProfile = UserFactory.Create(form);
            userProfile.Id = UniqueIdentifierGenerator.GenerateUserId();

            _userContactProfiles.Add(userProfile);

            var json = JsonSerializer.Serialize(_userContactProfiles);
            return _fileService.SaveContentToFile(json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating new user: {ex.Message}");
            return false;
        }
    }

    public IEnumerable<UserContactProfile> GetUserProfiles()
    {
        try
        {
            var json = _fileService.GetContentFromFile();
            if (string.IsNullOrEmpty(json)) 
                return new List<UserContactProfile>();

            _userContactProfiles = JsonSerializer.Deserialize<List<UserContactProfile>>(json) ?? new List<UserContactProfile>();
            return _userContactProfiles;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error retrieving user profiles: {ex.Message}");
            return new List<UserContactProfile>();
        }
    }

    public bool UpdateUserProfile(string userId, UserContactForm updatedForm)
    {

        var targetUser = _userContactProfiles.FirstOrDefault(u => u.Id == userId);
        if (targetUser == null)
        {
            Debug.WriteLine($"User with ID {userId} was not found.");
            return false;
        }

        if (!string.IsNullOrWhiteSpace(updatedForm.FirstName))
            targetUser.FirstName = updatedForm.FirstName;

        if (!string.IsNullOrWhiteSpace(updatedForm.LastName))
            targetUser.LastName = updatedForm.LastName;

        if (!string.IsNullOrWhiteSpace(updatedForm.Email))
            targetUser.Email = updatedForm.Email;

        if (!string.IsNullOrWhiteSpace(updatedForm.PhoneNumber))
            targetUser.PhoneNumber = updatedForm.PhoneNumber;

        if (!string.IsNullOrWhiteSpace(updatedForm.Address))
            targetUser.Address = updatedForm.Address;

        if (!string.IsNullOrWhiteSpace(updatedForm.PostalNumber))
            targetUser.PostalNumber = updatedForm.PostalNumber;

        if (!string.IsNullOrWhiteSpace(updatedForm.Locality))
            targetUser.Locality = updatedForm.Locality;

        try
        {
            json = JsonSerializer.Serialize(_userContactProfiles);
            return _fileService.SaveContentToFile(json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating user: {ex.Message}");
            return false;
        }
    }

    public bool DeleteUserProfile(string userId)
    {
        var targetUser = _userContactProfiles.FirstOrDefault(u => u.Id == userId);

        if (targetUser == null)
        {
            Debug.WriteLine($"User with ID {userId} was not found.");
            return false;
        }

        _userContactProfiles.Remove(targetUser);

        try
        {
            var json = JsonSerializer.Serialize(_userContactProfiles);
            return _fileService.SaveContentToFile(json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting user: {ex.Message}");
            return false;
        }
    }
}
