using Events.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Events.Tests.Unit.Events.Api.Controllers;

public class PingControllerTests
{
    [Fact]
    public void Ping_Returns_OkResult_With_Pong()
    {
        // Arrange
        var controller = new PingController();

        // Act
        var result = controller.Ping();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Pong", okResult.Value);
    }
}