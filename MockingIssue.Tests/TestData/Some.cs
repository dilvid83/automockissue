using MockingIssue.Common.Extensions;
using MockingIssue.Entities;

namespace MockingIssue.Tests.TestData;

public static class Some
{
    public static List<SomeEntity> Data =>
    [
        new SomeEntity
        {
            DateCreated = DateTime.Today,
            DateModified = DateTime.Today,
            DateDeleted = null,
            Info = "4088600079332",
            CountryId = "764AD7C9-6D42-466E-B137-8A4D38990F7D".ToGuid(),
            RegardingId = "2E8B8FD8-82D4-4C89-9D14-CF0A005867A5".ToGuid(),
            SomeModelId = "220A5668-2C99-4EA1-8887-3060944059F6".ToGuid()
        }
    ];
}