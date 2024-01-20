using Microsoft.EntityFrameworkCore;
using MockingIssue.Data.Interfaces;
using MockingIssue.Entities;

namespace MockingIssue.Data.Repositories;

public class SomeRepository(MyContext db) : ISomeRepository
{
    public async Task<List<SomeEntity>> GetBarcodesForItem(Guid regardingId)
    {
        var result = await db.SomeStuff.Where(be => be.RegardingId == regardingId).Include("Country").ToListAsync();

        return result;
    }

    public async Task<SomeEntity> Create(SomeEntity someEntity)
    {
        someEntity.DateCreated = DateTime.UtcNow;
        someEntity.DateModified = DateTime.UtcNow;

        await db.SomeStuff!.AddAsync(someEntity);

        await db.SaveChangesAsync();

        return someEntity;
    }

    public async Task<SomeEntity?> GetSomething(string info, Guid countryId, Guid regardingId)
    {
        var result = await db.SomeStuff!.Include("Country").SingleOrDefaultAsync(be => be.Info == info 
            && be.CountryId == countryId 
            && be.RegardingId == regardingId);

        return result;
    }
}