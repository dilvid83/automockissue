using MockingIssue.Models;

namespace MockingIssue.Business.Interfaces;

public interface ISomeManager
{
    Task<SomeModel> AddSomething(Guid regardingId, string info, Guid countryId);
}