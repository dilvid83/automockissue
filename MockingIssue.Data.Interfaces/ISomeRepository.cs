using MockingIssue.Entities;

namespace MockingIssue.Data.Interfaces;

public interface ISomeRepository
{
    Task<List<SomeEntity>> GetBarcodesForItem(Guid regardingId);
    Task<SomeEntity> Create(SomeEntity someEntity);
    Task<SomeEntity?> GetSomething(string info, Guid countryId, Guid regardingId);
}