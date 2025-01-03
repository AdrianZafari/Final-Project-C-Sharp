

using DTOs.DTOs;

namespace Social.Handlers;

public class ValidateUserContactForm
{
    public static bool IsValidUserContactForm(UserContactForm form)
    {
        return !string.IsNullOrWhiteSpace(form.FirstName) &&
               !string.IsNullOrWhiteSpace(form.LastName);
    }

}
