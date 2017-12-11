using OfficePlanApi.Domain.Interfaces.LifetimeScopes;
using System;

namespace OfficePlanApi.Domain.Interfaces.Services
{
    public interface IDateTimeService : ISingleInstance
    {
        DateTime GetNowDateTime();
    }
}
