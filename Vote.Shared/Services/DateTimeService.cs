using System;
using Vote.Application.Common.Interfaces;

namespace Vote.Shared.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
