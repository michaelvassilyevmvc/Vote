using System;

namespace Vote.Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime NowUtc { get;  }
    }
}
