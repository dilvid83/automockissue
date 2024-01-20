using Microsoft.Extensions.Options;
using MockingIssue.Common;

namespace MockingIssue.Tests.Helper;

public static class OptionsHelper
{
    public static IOptions<ApiSettings> GetSettings => Options.Create(new ApiSettings
    {
        Option1 = "SomeOption",
    });
}