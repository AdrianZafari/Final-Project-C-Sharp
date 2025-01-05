
using Social.Handlers;

namespace FinalProject.Test.Handlers;

public class UniqueIdentifierGenerator_Tests
{
    [Fact]
    public void GenerateUserId_ReturnsStringOfTypeGuid()
    {
        // Act 
        string id = UniqueIdentifierGenerator.GenerateUserId();

        // Assert 
        Assert.False(string.IsNullOrEmpty(id));
        Assert.True(Guid.TryParse(id, out _));
    }

}
