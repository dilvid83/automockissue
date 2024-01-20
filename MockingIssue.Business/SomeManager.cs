using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MockingIssue.Business.Interfaces;
using MockingIssue.Common;
using MockingIssue.Data.Interfaces;
using MockingIssue.Entities;
using MockingIssue.Models;

namespace MockingIssue.Business;

public class SomeManager(ILogger<SomeManager> log, IOptions<ApiSettings> apiSettings, ISomeRepository someRepository) 
    : BaseManager(log, apiSettings), ISomeManager
{
    public async Task<SomeModel> AddSomething(Guid regardingId, string info, Guid countryId)
    {
        var someEntity = await someRepository.GetSomething(info, countryId, regardingId);

        if (someEntity == null)
        {
            someEntity = new SomeEntity
            {
                Info = info,
                CountryId = countryId,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                RegardingId = regardingId
            };

            await someRepository.Create(someEntity);

            someEntity = await someRepository.GetSomething(info, countryId, regardingId);
        }

        return new SomeModel
        {
            Info = someEntity!.Info,
            SomeModelId = someEntity!.SomeModelId,
            CountryId = someEntity!.CountryId,
            CountryName = someEntity.Country.Name,
            RegardingId = someEntity.RegardingId
        };
    }
}