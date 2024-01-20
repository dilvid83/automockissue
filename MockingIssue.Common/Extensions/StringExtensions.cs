namespace MockingIssue.Common.Extensions;

public static class StringExtensions
{
    public static Guid ToGuid(this string? value)
    {
        if (!Guid.TryParse(value, out var result))
            throw new FormatException($"String '{value}' is not a Guid");

        return result;
    }
}