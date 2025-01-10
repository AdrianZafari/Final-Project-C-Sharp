

using DTOs.DTOs;

namespace Social.Interfaces;

public interface IUserUpdate
{
    bool UpdateUserProfile(string userId, UserContactForm updatedForm);
}
