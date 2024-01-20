using MockingIssue.Data;
using MockingIssue.Tests.TestData;
using Moq;
using Moq.EntityFrameworkCore;

namespace MockingIssue.Tests.Helper;

public static class ContextHelper
{
    public static void AddDbSets(ref Mock<MyContext> mockContext)
    {
        mockContext.Setup(x => x.SomeStuff).ReturnsDbSet(Some.Data);
    }
}