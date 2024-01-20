using MockingIssue.Common.Extensions;
using MockingIssue.Entities;

namespace MockingIssue.Tests.TestData;

public static class Country
{
    public static List<CountryEntity> Data =>
    [
        new CountryEntity
        {
            DateCreated = DateTime.Today,
            DateModified = DateTime.Today,
            DateDeleted = null,
            Name = "United Kingdom",
            CountryCode = "GB",
            CountryId = "764AD7C9-6D42-466E-B137-8A4D38990F7D".ToGuid()
        },
        new CountryEntity
        {
            DateCreated = DateTime.Today,
            DateModified = DateTime.Today,
            DateDeleted = null,
            Name = "Canada",
            CountryCode = "CA",
            CountryId = "6096B007-0858-4D76-91D5-F2F4DC9458D7".ToGuid()
        }
    ];
}