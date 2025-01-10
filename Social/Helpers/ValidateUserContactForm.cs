

using DTOs.DTOs;

namespace Social.Helpers;

public class ValidateUserContactForm
{
    public static bool IsValidUserContactForm(UserContactForm form)
    {
        return !string.IsNullOrWhiteSpace(form.FirstName) &&
               !string.IsNullOrWhiteSpace(form.LastName);
    }

}
