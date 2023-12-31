﻿using FluentAssertions;
using FridgeConsole.DataAccess;
using FridgeConsole.Models;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace FridgeConsoleTests.DataAccessTests;

[ExcludeFromCodeCoverage]
[TestFixture]
public class JsonDataAccessTests
{
    private JsonDataAccess<CharacterInventoryModel> _dataAccess;

    [SetUp]
    public void SetUp()
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\DataAccessTests\inventory.json");
        var options = Options.Create(new DataAccessOptions { FilePath = path });
        _dataAccess = new(options);
    }

    [Test]
    public void GetData_Gets_All_Models_From_File()
    {
        // Arrange
        var expected = new List<CharacterInventoryModel>
        {
            new() { Character = 'a', QuantityAvailable = 2 },
            new() { Character = 'b', QuantityAvailable = 5 }
        }.AsEnumerable();

        // Act
        var actual = _dataAccess.GetData();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
