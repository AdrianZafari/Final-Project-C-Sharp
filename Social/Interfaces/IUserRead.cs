using DTOs.Models;

namespace Social.Interfaces;

public interface IUserRead
{
    IEnumerable<UserContactProfile> GetUserProfiles();
}
