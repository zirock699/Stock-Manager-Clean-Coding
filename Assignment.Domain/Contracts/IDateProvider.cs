using System;

namespace Assignment.Domain.Contracts
{
    public interface IDateProvider
    {
        DateTime Now();
    }
}
