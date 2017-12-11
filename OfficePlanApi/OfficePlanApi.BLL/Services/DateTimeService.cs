using OfficePlanApi.Domain.Interfaces.Services;
using System;

namespace OfficePlanApi.BLL.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetNowDateTime()
        {
            return DateTime.Now;
        }
    }
}
