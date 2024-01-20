using FluentAssertions;
using Microsoft.Extensions.Options;
using MockingIssue.Business;
using MockingIssue.Common;
using MockingIssue.Common.Extensions;
using MockingIssue.Data;
using MockingIssue.Data.Interfaces;
using MockingIssue.Data.Repositories;
using MockingIssue.Tests.Helper;
using MockingIssue.Tests.TestData;
using Moq;
using Moq.AutoMock;

namespace MockingIssue.Tests;

public class Tests
{
    private AutoMocker _autoMocker = new AutoMocker();
    private Mock<MyContext> _mockContext;
    
    [SetUp]
    public void SetUp()
    {
        _autoMocker = new AutoMocker();
        _mockContext = new Mock<MyContext>();
        ContextHelper.AddDbSets(ref _mockContext);
        
        _autoMocker.Use<MyContext>(_mockContext.Object);
        _autoMocker.Use<IOptions<ApiSettings>>(OptionsHelper.GetSettings);
    }

    [TestCase("22A8EB72-F4F9-40E6-A210-BAF7AF732F40", "1234567890", "764AD7C9-6D42-466E-B137-8A4D38990F7D")]
    public async Task Fails(string regardingId, string info, string countryId)
    {
        //Arrange
        var countryEntity = Country.Data.Single(c => c.CountryId == countryId.ToGuid());
        
        var someRepository = _autoMocker.CreateInstance<SomeRepository>();
        
        _autoMocker.Use<ISomeRepository>(someRepository);

        var someManager = _autoMocker.CreateInstance<SomeManager>();
        _autoMocker.VerifyAll();

        //Act
        var result = await someManager.AddSomething(regardingId.ToGuid(), info, countryId.ToGuid());
        
        //Assert
        result.Should().NotBeNull();
        result.CountryId.ToString().Should().Be("764AD7C9-6D42-466E-B137-8A4D38990F7D");
        result.Info.Should().Be(info);
        result.CountryName.Should().Be(countryEntity.Name);
        result.RegardingId.Should().Be(regardingId);
    }
}