using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MockingIssue.Common;

namespace MockingIssue.Business;

public class BaseManager
{
    protected readonly ILogger Log;
    protected readonly ApiSettings _applicationSettings;

    protected BaseManager(ILogger log, IOptions<ApiSettings> apiSettings)
    {
        Log = log;
        _applicationSettings = apiSettings.Value;
    }
}