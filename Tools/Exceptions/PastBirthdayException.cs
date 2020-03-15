using System;

namespace WPFProject_Lab2.Tools.Exceptions
{
    internal class PastBirthdayException: Exception
    {

        internal PastBirthdayException(string message) : base(message) { }
    }
}
