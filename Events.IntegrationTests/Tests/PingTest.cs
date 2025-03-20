using IntegrationTests.Tests;

namespace IntegrationTests.Events;

using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using FluentAssertions;


public class PingTest : IClassFixture<IntegrationTestWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public PingTest(IntegrationTestWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient(); // Starts the test server
    }

    [Fact]
    public async Task Ping_ShouldReturnPong()
    {
        // Act
        var response = await _client.GetAsync("api/Ping");
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNull();
        content.Should().Be("Pong");
    }
}