using System;

namespace OfficePlanApi.Domain.Exceptions
{
    [Serializable]
    public class UnexpectedNullValueException : Exception
    {
        public UnexpectedNullValueException(string message)
            : base(message)
        {
        }
    }
}
