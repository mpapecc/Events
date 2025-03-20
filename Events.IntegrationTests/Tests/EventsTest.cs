using Events.Domain.Entities;
using IntegrationTests.Tests;

namespace IntegrationTests.Events;

using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using FluentAssertions;


public class EventsTest : IClassFixture<IntegrationTestWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly IntegrationTestWebApplicationFactory<Program>
        _factory;

    public EventsTest(IntegrationTestWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    [Fact]
    public async Task Events_ShouldReturnListOfEvents()
    {
        // Act
        var response = await _client.GetAsync("api/Event/GetEvents");
        
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadFromJsonAsync<List<Event>>();
        
        content.Should().NotBeNull();
        //content should contain at least one item
        content.Should().NotBeEmpty();
        content.Should().HaveCount(2);
        
        // content.Should().Be("Pong");
    }
}