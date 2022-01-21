using Assignment.Domain.Contracts;
using System;

namespace Assignment.Infrastruction
{
    /// <summary>
    /// it the best practice to abstract the date so we can change it's format in one place 
    /// and will be affect everywhere 
    /// </summary>
    public class DateProvider : IDateProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
