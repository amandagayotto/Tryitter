using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;

namespace tryitter.Test;

public class TestUsersController : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly string BasePath = "/Users";
    public TestUsersController(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
}