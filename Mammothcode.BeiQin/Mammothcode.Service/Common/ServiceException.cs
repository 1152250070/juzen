using System;

namespace Mammothcode.Service
{
    /// <summary>
    /// Service顶级异常,此异常不记录日志，仅用于打断流程
    /// </summary>
    public class ServiceException : Exception
    {
        public ServiceException()
        {

        }
        public ServiceException(string message) : base(message)
        {

        }

    }
    public class ArgumentNullServiceException : Exception
    {
        public ArgumentNullServiceException(string message) : base("cannot be emipt:" + char.ToLower(message[0]) + message.Substring(1))
        {
        }
    }
    public class LoginException : ServiceException
    {
        public LoginException(string message) : base(message)
        {

        }
    }
}
