

using System.Diagnostics;

namespace Social.Handlers;

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
