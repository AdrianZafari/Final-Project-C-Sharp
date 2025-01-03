

using DTOs.DTOs;
using DTOs.Models;

namespace Social.Interfaces;

public interface IUserService
{
    bool CreateUserProfile(UserContactForm form);
    IEnumerable<UserContactProfile> GetUserProfiles();
    bool UpdateUserProfile(string userId, UserContactForm updatedForm);
    bool DeleteUserProfile(string userId);
}
