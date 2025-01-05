

using Data.Interfaces;
using Moq;

namespace FinalProject.Test.Services;

public class FileService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;

    public FileService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
    }

    [Fact]
    public void SaveContentToFile_NonEmptyContent_ReturnsTrue()
    {
        // Arrange
        var fileContent = " { \"key\" : \"value\" } ";
        _fileServiceMock.Setup(fs => fs.SaveContentToFile(fileContent)).Returns(true);

        // Act
        var result = _fileServiceMock.Object.SaveContentToFile(fileContent);

        // Assert
        Assert.True(result);
        _fileServiceMock.Verify(fs => fs.SaveContentToFile(fileContent), Times.Once);
    }

    [Fact]
    public void SaveContentToFile_EmptyContent_ReturnsFalse()
    {
        // Arrange
        var fileContent = "";
        _fileServiceMock.Setup(fs => fs.SaveContentToFile(fileContent)).Returns(false);

        // Act
        var result = _fileServiceMock.Object.SaveContentToFile(fileContent);

        // Assert
        Assert.False(result);
        _fileServiceMock.Verify(fs => fs.SaveContentToFile(fileContent), Times.Once);
    }

    [Fact]
    public void GetContentFromFile_FileHasContent_ReturnsString()
    {
        // Arrange
        var fileContent = " { \"key\" : \"value\" } ";
        _fileServiceMock.Setup(fs => fs.GetContentFromFile()).Returns(fileContent);

        // Act
        var result = _fileServiceMock.Object.GetContentFromFile();

        // Assert
        Assert.Equal(fileContent, result);
        _fileServiceMock.Verify(fs => fs.GetContentFromFile(), Times.Once);
    }

    [Fact]
    public void GetContentFromFile_FileEmpty_ReturnsEmptyString()
    {
        // Arrange
        _fileServiceMock.Setup(fs => fs.GetContentFromFile()).Returns(string.Empty);

        // Act
        var result = _fileServiceMock.Object.GetContentFromFile();

        // Assert
        Assert.Equal(string.Empty, result);
        _fileServiceMock.Verify(fs => fs.GetContentFromFile(), Times.Once);

    }


}
