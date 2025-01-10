

using System.Diagnostics;

namespace Social.Helpers;

public class UniqueIdentifierGenerator
{
    public static string GenerateUserId()
    {
        try
        {
            return Guid.NewGuid().ToString();
        } 
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return null!;
        }
    }

}
