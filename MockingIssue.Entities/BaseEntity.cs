using System.Text;

namespace MockingIssue.Entities;

public class BaseEntity
{
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    public DateTime? DateDeleted { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var objectProperties in GetType().GetProperties().Where(objectProperties => objectProperties.PropertyType == typeof(short) || objectProperties.PropertyType == typeof(short?) || objectProperties.PropertyType == typeof(int) || objectProperties.PropertyType == typeof(int?) || objectProperties.PropertyType == typeof(long) || objectProperties.PropertyType == typeof(long?) || objectProperties.PropertyType == typeof(DateTime) || objectProperties.PropertyType == typeof(DateTime?) || objectProperties.PropertyType == typeof(Guid) || objectProperties.PropertyType == typeof(Guid?) || objectProperties.PropertyType == typeof(double) || objectProperties.PropertyType == typeof(double?) || objectProperties.PropertyType == typeof(bool) || objectProperties.PropertyType == typeof(bool?) || objectProperties.PropertyType == typeof(long) || objectProperties.PropertyType == typeof(long?) || objectProperties.PropertyType == typeof(decimal) || objectProperties.PropertyType == typeof(decimal?) || objectProperties.PropertyType == typeof(int) || objectProperties.PropertyType == typeof(int?) || objectProperties.PropertyType == typeof(string)))
            sb.Append($" {objectProperties.Name} : \"{objectProperties.GetValue(this)}\" ,");
        return $"{{ {sb.ToString().TrimEnd(',')} }}";
    }
}