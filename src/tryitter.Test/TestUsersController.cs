using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Net;

namespace tryitter.Test;

public class TestUsersController : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public TestUsersController(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact(DisplayName = "Teste para Users com Status OK")]
    public async Task TestUsersSuccess()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/Users");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

}