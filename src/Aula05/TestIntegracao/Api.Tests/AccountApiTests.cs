using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using Api.Models;
using Xunit;

namespace Api.Tests;

public class AccountApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public AccountApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAccounts_ShouldReturnList()
    {
        // Act
        var response = await _client.GetAsync("/api/accounts");

        // Assert
        response.EnsureSuccessStatusCode();
        var accounts = await response.Content.ReadFromJsonAsync<List<Account>>();
        Assert.NotNull(accounts);
    }

    [Fact]
    public async Task GetAccounts_ShouldReturnAnAccount()
    {
        // Act
        var response = await _client.GetAsync("/api/accounts/1");

        // Assert
        response.EnsureSuccessStatusCode();
        var accounts = await response.Content.ReadFromJsonAsync<Account>();
        Assert.NotNull(accounts);
    }


    [Fact]
    public async Task PostAccount_ShouldCreateAccount()
    {
        // Arrange
        var newAccount = new Account { Owner = "Maria", Balance = 500 };

        // Act
        var response = await _client.PostAsJsonAsync("/api/accounts", newAccount);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        var created = await response.Content.ReadFromJsonAsync<Account>();
        Assert.NotNull(created);
        Assert.Equal("Maria", created!.Owner);
        Assert.Equal(500, created.Balance);
    }
}
