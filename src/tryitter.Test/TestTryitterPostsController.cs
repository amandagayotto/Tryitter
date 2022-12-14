using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Net;
namespace tryitter.Test;
public class TestTryitterPostsController : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public TestTryitterPostsController(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    [Fact(DisplayName = "Teste para TryitterPosts com Status OK")]
    public async Task TestTryitterPostsSuccess()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/TryitterPosts");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}